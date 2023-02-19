using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserEcoRepository : IUserEcoRepository
{
    private readonly Eco23Context _context;

    public UserEcoRepository(Eco23Context context)
    {
        _context = context;
    }

    public Task<IQueryable<UserEco>> ListSelectUser()
    {
        IQueryable<UserEco> query = _context.UserEcos.AsNoTracking();
        return Task.FromResult(query);
    }
}
