using EcommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceAPI.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		private readonly ECommerceDbContext _context;

		public WriteRepository(ECommerceDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>(); //ilgili dbset elde edildi.

		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry=await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> AddRangeAsync(List<T> datas)
		{
			await Table.AddRangeAsync(datas);
			return true;
		}

		public bool Remove(T model)
		{
			EntityEntry<T> entityEntry=Table.Remove(model);
			return entityEntry.State == EntityState.Deleted;
		}
		public bool RemoveRange(List<T> datas)
		{
			Table.RemoveRange(datas);
			return true;
		}

		public async Task<bool> RemoveAsync(string id)
		{
			T model= await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
			return Remove(model);
		}


		public bool Update(T model)
		{
			//asenkron olmayan metodu bu şekilde asenkron yapabiliriz.
			//EntityEntry entityEntry await Task.Run(()=>Table.Update(model));
			EntityEntry entityEntry =Table.Update(model);
			return entityEntry.State==EntityState.Modified;
		}
		public async Task<int> SaveAsync()
		=> await _context.SaveChangesAsync();

	
	}
}
