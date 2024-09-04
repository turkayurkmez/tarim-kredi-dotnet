using eshop.Domain;

namespace eshop.Application.Contract.Repositories
{
    public interface IRepository<T> where T : IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
