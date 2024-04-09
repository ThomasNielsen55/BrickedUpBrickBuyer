namespace BrickedUpBrickBuyer.Data
{
	public class EFBrickRepository : IBrickRepository
	{
		private BrickContext _context;
		public EFBrickRepository(BrickContext temp)
		{
			_context = temp;
		}
		public List<Customer> Customers => _context.Customers.ToList();
		public List<LineItem> LineItems => _context.LineItems.ToList();
		public List<Order> Orders => _context.Orders.ToList();
		public List<Product> Products => _context.Products.ToList();
	}
}
