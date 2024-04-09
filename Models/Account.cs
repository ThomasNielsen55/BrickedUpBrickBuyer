using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrickedUpBrickBuyer.Models
{
    public class Account
    {
        [Key]
        [ForeignKey("customer_ID")]
        public int customer_ID {  get; set; }
        public Customer? customer { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public int access_level { get; set; }
        public int salt { get; set; }
    }
}
