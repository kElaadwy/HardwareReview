using HardwareReview.Data;
using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public bool CompanyExists(int id)
        {
            return _context.Companies.Any(x => x.Id == id);
        }

        public ICollection<Company> GetCompanies()
        {
            return _context.Companies.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Company> GetCompaniesOfHardware(int HardwareId)
        {
            return _context.HardwareCompanies.Where(x => x.HardwareId == HardwareId).Select(y => y.Company).ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Company> GetCompanyByName(string name)
        {
            return _context.Companies.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public ICollection<Hardware> GetHardwaresOfCompany(int CompanyId)
        {
            return _context.HardwareCompanies.Where(x => x.CompanyId == CompanyId).Select(y => y.Hardware).ToList();
        }

        public bool CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
