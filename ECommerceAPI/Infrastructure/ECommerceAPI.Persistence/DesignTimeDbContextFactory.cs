using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
	{
		public ECommerceDbContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<ECommerceDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
			return new(dbContextOptionsBuilder.Options);
		}
	}
}
