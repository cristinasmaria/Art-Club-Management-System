// Code written by Savescu Razvan
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interfaces;

namespace API.Services
{
	public abstract class AbstractService<T> : IService<T>
		where T : class
	{
		protected readonly UnitOfWork _unitOfWork;

		public AbstractService(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public virtual Task AddAsync(T entity) => Task.CompletedTask;

		public virtual IQueryable<T> All() => null;

		public virtual Task DeleteAsync(T entity) => Task.CompletedTask;

		public virtual Task<T> FindByIdAsync(int? id) => Task.FromResult<T>(null);

		public virtual Task UpdateAsync(T entity) => Task.CompletedTask;
	}
}
