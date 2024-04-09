using System.ComponentModel.DataAnnotations;

namespace BrickedUpBrickBuyer.Models
{
    public class LineItem
    {
        [Key]
        public int transaction_ID { get; set; }
        public int product_ID { get; set; }
        public int qty { get; set; }
        public int rating { get; set; }
    }
}
