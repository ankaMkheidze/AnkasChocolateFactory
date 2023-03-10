using AnkasChocolateFactory.Data;

namespace AnkasChocolateFactory.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetAsync(int? id);
    Task<List<T>> GetAllAsync();    
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int? id);
    Task<bool> Exists(int? id);

}

