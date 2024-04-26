using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Application.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		DbSet<T> Table { get; }
	}
}
