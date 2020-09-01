namespace Application.Reviews.Commands.CreateReviewCommand
{
    public interface ICreateReviewCommand
    {
        void Execute(CreateReviewModel createReviewModel);
    }
}