using Microsoft.EntityFrameworkCore;

namespace BrickedUpBrickBuyer.Models
{
    public class BrickedUpBrickBuyerContext : DbContext
    {
        public BrickedUpBrickBuyerContext (DbContextOptions<BrickedUpBrickBuyerContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
      

    }
}
