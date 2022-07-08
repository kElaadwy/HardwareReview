namespace HardwareReview.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<HardwareCompany> HardwareCompanies { get; set; }

    }
}
