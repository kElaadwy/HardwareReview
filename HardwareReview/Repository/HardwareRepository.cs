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

        public bool CreateHardware(int companyId, int categoryId, Hardware hardware)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == companyId);
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

            var hardwareCompany = new HardwareCompany()
            {
                CompanyId = companyId,
                Company = company,

                HardwareId = hardware.Id,
                Hardware = hardware,
            };

            _context.HardwareCompanies.Add(hardwareCompany);

            var hardwareCategory = new HardwareCategory()
            {
                CategoryId = categoryId,
                Category = category,

                HardwareId = hardware.Id,
                Hardware = hardware
            };

            _context.HardwareCategories.Add(hardwareCategory);

            _context.Hardwares.Add(hardware);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
