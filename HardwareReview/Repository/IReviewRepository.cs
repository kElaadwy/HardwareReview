using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReviewById(int id);
        ICollection<Review> GetReviewsOfHardware(int hardwareId);
        bool ReviewExists(int id);
    }
}
