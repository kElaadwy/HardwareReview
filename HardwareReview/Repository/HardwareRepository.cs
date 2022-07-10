using HardwareReview.Data;
using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public class HardwareRepository: IHardwareRepository
    {
        private readonly DataContext _context;

        public HardwareRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Hardware> GetHardwares()
        {
            return _context.Hardwares.OrderBy(x => x.Id).ToList();
        }

        public Hardware GetHardwareById(int id)
        {
            return _context.Hardwares.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Hardware> GetHardwareByName(string name)
        {
            return _context.Hardwares.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public decimal GetHardwareRating(int HardwareId)
        {
            //var review = _context.Reviews.Where(x => x.Id == HardwareId);

            //if(review.Count() <= 0)
            //    return 0;

            //return ((decimal)review.Sum(r => r.) / review.Count()); 

            // 6. GET & Read Methods [PART 1]
            throw new NotImplementedException();
        }

        public bool HardwareExists(int HardwareId)
        {
            return _context.Hardwares.Any(x => x.Id == HardwareId);
        }
    }
}
