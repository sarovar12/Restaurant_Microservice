using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.EmailAPI.Models
{
    public class EmailLogger
    {
        [Key]
        public int EmailId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime? EmailSentTime { get; set; }
    }
}
