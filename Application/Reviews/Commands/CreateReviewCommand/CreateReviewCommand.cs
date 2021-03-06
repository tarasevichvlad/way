using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Reviews;

namespace Application.Reviews.Commands.CreateReviewCommand
{
    public class CreateReviewCommand : ICreateReviewCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewCommand(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _reviewRepository = reviewRepository;
        }

        public void Execute(CreateReviewModel createReviewModel)
        {
            var from = _userRepository.Get(createReviewModel.From);
            var to = _userRepository.Get(createReviewModel.To);
            var ratings = _reviewRepository
                .GetAll()
                .Where(x => x.To.Id.Equals(to.Id))
                .Select(x => x.Rating)
                .ToList();
            
            ratings.Add(createReviewModel.Rating);

            to.UpdateRating(ratings.Average());

            var review = new Review(from, to, createReviewModel.Body, createReviewModel.Rating);

            _reviewRepository.Add(review);

            _unitOfWork.Save();
        }
    }
}