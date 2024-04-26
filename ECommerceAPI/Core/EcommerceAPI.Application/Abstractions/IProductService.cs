using ECommerceAPI.Domain.Entities;

namespace EcommerceAPI.Application.Abstractions
{
	public interface IProductService
	{
		List<Product> GetProducts();
	}
}
