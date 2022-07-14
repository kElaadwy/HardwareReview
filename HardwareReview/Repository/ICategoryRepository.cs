using HardwareReview.Models;

namespace HardwareReview.Repository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int id);
        ICollection<Hardware> GetHardwaresByCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool Save();

    }
}
