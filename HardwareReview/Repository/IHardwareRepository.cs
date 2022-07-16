using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public interface IHardwareRepository
    {
        ICollection<Hardware> GetHardwares();
        Hardware GetHardwareById(int id);
        ICollection<Hardware> GetHardwareByName(string name);
        Decimal GetHardwareRating(int HardwareId);
        bool HardwareExists(int HardwareId);
        bool CreateHardware(int companyId, int categoryId, Hardware hardware);
        bool Save();

    }
}
