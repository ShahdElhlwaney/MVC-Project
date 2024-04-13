namespace FirstProject.Models
{
	public class ProductSampleData
	{
		List<Product> products;
		public ProductSampleData()
		{
			products = new List<Product>();
			products.Add(new Product { Id = 1, Name = "Iphone1", Description = "Iphone1", Image = "shahod.jpg" });
			products.Add(new Product { Id = 2, Name = "Iphone2", Description = "Iphone2", Image = "rice.png" });
			products.Add(new Product { Id = 3, Name = "Iphone3", Description = "Iphone3", Image = "banana.png" });
			products.Add(new Product { Id = 4, Name = "Iphone4", Description = "Iphone4", Image = "rice.png" });
		}
		public List<Product>GetAll()
		{
			return products;
		}
		public Product GetById(int id)
		{
			return products.FirstOrDefault(p => p.Id == id);
		}
	}
}
