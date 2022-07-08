namespace HardwareReview.Models
{
    public class Hardware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<HardwareCompany> HardwareCompanies { get; set; }
        public ICollection<HardwareCategory> HardwareCategories { get; set; }

    }
}
