using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence
{

	public static class ServiceRegistiration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
		}
	}
}
