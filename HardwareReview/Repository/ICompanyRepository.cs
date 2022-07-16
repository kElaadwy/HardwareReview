using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public interface ICompanyRepository
    {
        ICollection<Company> GetCompanies();
        Company GetCompanyById(int id);
        ICollection<Company> GetCompanyByName(string name);
        ICollection<Hardware> GetHardwaresOfCompany(int CompanyId);
        ICollection<Company> GetCompaniesOfHardware(int HardwareId);
        bool CompanyExists(int id);
        bool CreateCompany(Company company);
        bool UpdateCompany(Company company);
        bool Save();
    }
}
