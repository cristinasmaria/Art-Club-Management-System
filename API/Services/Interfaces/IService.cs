using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
	public interface IService<T>
		where T : class
	{
		IQueryable<T> All();
		Task AddAsync(T userConversation);
		Task<T> FindByIdAsync(int? id);
		Task UpdateAsync(T userConversation);
		Task DeleteAsync(T userConversation);
	}
}
