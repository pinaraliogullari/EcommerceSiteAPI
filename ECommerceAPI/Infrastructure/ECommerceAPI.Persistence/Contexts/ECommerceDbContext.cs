using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerceAPI.Persistence.Contexts
{
	public class ECommerceDbContext : DbContext
	{
		public ECommerceDbContext(DbContextOptions options) : base(options)
		{
		}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			//ChangeTracker:Entityler üzerindeki update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.
			var data = ChangeTracker.Entries<BaseEntity>();
			foreach (var item in data)
			{
				_= item.State switch
				{
					EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
					EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
					_=>DateTime.UtcNow
				};
			}
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
