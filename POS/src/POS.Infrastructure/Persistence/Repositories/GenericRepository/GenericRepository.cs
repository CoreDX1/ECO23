using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces.GenericRepository;

namespace POS.Infrastructure.Persistence.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly Eco23Context _context;
    private readonly DbSet<T> _table;

    public GenericRepository(Eco23Context context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        IEnumerable<T> entity = await _table.AsNoTracking().ToListAsync();
        return entity;
    }

    public async Task<T> GetById(int id)
    {
        T? entity = await _table.FindAsync(id);
        return entity!;
    }

    public async Task<T> Create(T entity)
    {
        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Update(T entity)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        T? entity = await GetById(id);
        _table.Remove(entity);
        var recordsAffected = await _context.SaveChangesAsync();
        return true;
    }
}
