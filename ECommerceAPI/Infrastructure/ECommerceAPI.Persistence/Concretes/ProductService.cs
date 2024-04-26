using EcommerceAPI.Application.Abstractions;
using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Persistence.Concretes
{
	public class ProductService : IProductService
	{
		public List<Product> GetProducts()
		 
			=> new()
			{
				new(){Id=Guid.NewGuid(),Name="Product 1",Stock=10,Price=100,},
				new(){Id=Guid.NewGuid(),Name="Product 2",Stock=10,Price=200,},
				new(){Id=Guid.NewGuid(),Name="Product 3",Stock=10,Price=300,},
				new(){Id=Guid.NewGuid(),Name="Product 4",Stock=10,Price=400,},
				new(){Id=Guid.NewGuid(),Name="Product 5",Stock=10,Price=500,},
			};
		
	}
}
