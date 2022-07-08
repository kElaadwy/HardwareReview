namespace HardwareReview.Models
{
    public class HardwareCategory
    {
        public int HardwareId { get; set; }
        public int CategoryId { get; set; }
        public Hardware Hardware { get; set; }
        public Category Category{ get; set; }

    }
}
