using EcommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceAPI.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		private readonly ECommerceDbContext _context;

		public ReadRepository(ECommerceDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table =>_context.Set<T>();

		public IQueryable<T> GetAll()
		=> Table;

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
		=>Table.Where(predicate);
		
		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
		=>await Table.FirstOrDefaultAsync(predicate);
		public async Task<T> GetByIdAsync(string id)
		=>await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

	}
}
