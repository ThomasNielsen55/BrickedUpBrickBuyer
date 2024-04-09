using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrickedUpBrickBuyer.Models
{
    public class Product
    {
        [Key]
        [ForeignKey("")]
        public int productId {  get; set; }
        public string? name { get; set; }
        public int year { get; set; }
        public int num_parts { get; set; }
        public decimal price { get; set; }
        public string? img_link { get; set; }
        public string? primary_color { get; set; }
        public string? secondary_color { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public int recommendation1 { get; set; }
        public int recommendation2 { get; set; }
        public int recommendation3 { get; set; }
        public int recommendation4 { get; set; }
        public int recommendation5 { get; set; }

    }
}
