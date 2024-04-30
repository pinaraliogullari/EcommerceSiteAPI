using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using EcommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Repositories;

namespace ECommerceAPI.Persistence
{

	public static class ServiceRegistiration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
		//DbContextin sahip olduğu yaşam döngüsüne göre  servis repositoryleri ıoc ye eklendi.(addscoped)
			services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
			services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
			services.AddScoped<IOrderReadRepository,OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
			services.AddScoped<IProductReadRepository,ProductReadRepository>();
			services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
		}
	}
}
