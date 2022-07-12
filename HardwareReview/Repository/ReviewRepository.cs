using HardwareReview.Data;
using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public Review GetReviewById(int id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfHardware(int hardwareId)
        {
            return _context.Reviews.Where(r => r.Hardware.Id == hardwareId).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }
    }
}
