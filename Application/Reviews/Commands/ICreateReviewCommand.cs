namespace Application.Reviews.Commands
{
    public interface ICreateReviewCommand
    {
        void Execute(CreateReviewModel createReviewModel);
    }
}