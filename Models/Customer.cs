using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrickedUpBrickBuyer.Models
{
    public class Customer
    {
        [Key]
        public int customer_ID { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? birth_date { get; set; }
        public string? country_of_residence { get; set; }
        public string? gender { get; set; }
        //public int age { get; set; }
        //public int recommendation1 { get; set; }
        //public int recommendation2 { get; set; }
        //public int recommendation3 { get; set; }
        //public int recommendation4 { get; set; }
        //public int recommendation5 { get; set; }
    }
}
