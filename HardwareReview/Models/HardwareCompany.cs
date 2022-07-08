namespace HardwareReview.Models
{
    public class HardwareCompany
    {
        public int HardwareId { get; set; }
        public int CompanyId { get; set; }
        public Hardware Hardware { get; set; }
        public Company Company { get; set; }
    }
}
