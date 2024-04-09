namespace BrickedUpBrickBuyer.Data
{
	public class EFBrickRepository : IBrickRepository
	{
		private BrickContext _context;
		public EFBrickRepository(BrickContext temp)
		{
			_context = temp;
		}
		public IQueryable<Customer> Customers => _context.Customers;
		public IQueryable<LineItem> LineItems => _context.LineItems;
		public IQueryable<Order> Orders => _context.Orders;
		public IQueryable<Product> Products => _context.Products;
	}
}
