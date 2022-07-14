using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int id);
        Country GetCountryByCompany(int CompanyId);
        ICollection<Company> GetCompaniesFromCountry(int CountryId);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool Save();

    }
}
