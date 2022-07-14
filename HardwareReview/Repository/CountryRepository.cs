using HardwareReview.Data;
using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(country => country.Id == id);
        }

        public ICollection<Company> GetCompaniesFromCountry(int CountryId)
        {
            return _context.Companies.Where(x => x.Country.Id == CountryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(x => x.Id).ToList();
        }

        public Country GetCountryByCompany(int CompanyId)
        {
            return _context.Companies.Where(x => x.Id == CompanyId).Select(y => y.Country).FirstOrDefault();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Countries.Add(country);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
