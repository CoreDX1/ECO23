using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces.GenericRepository;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(int id);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(int id);
    public Task<T> Create(T entity);
}
