using EcommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories
{
	public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
	{
		public CustomerReadRepository(ECommerceDbContext context) : base(context)
		{
		}
	}
}
