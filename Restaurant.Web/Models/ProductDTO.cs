
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Web.Models
{
    public class ProductDTO
    {
      
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DateDeleted { get; set; }
        [Range(1, 100)]
        public int Count { get; set; } = 1;

    }
}
