namespace BrickedUpBrickBuyer.Data
{
	public interface IBrickRepository
	{
		
		List<Customer> Customers { get; }
		List<LineItem> LineItems { get; }
		List<Order> Orders { get; }
		List<Product> Products { get; }


	}
}
