using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IUserEcoRepository UserEco { get; private set; }
    private readonly Eco23Context _context;

    public UnitOfWork(Eco23Context context)
    {
        _context = context;
        UserEco = new UserEcoRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
