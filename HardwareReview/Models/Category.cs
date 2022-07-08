namespace HardwareReview.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HardwareCategory> HardwareCategories { get; set; }

    }
}
