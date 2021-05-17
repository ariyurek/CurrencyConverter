using CurrencyConverter.Domain.Common;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
