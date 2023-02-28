using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Infrastructure.Persistence.Repositories.GenericRepository;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserEcoRepository : GenericRepository<UserEco>, IUserEcoRepository
{
    private readonly Eco23Context _context;

    public UserEcoRepository(Eco23Context context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEco>> ListSelectUser()
    {
        IEnumerable<UserEco> user = await _context.UserEco
            .Include<UserEco, UserPermission>(e => e.UserPermissions)
            .Include<UserEco, UserProfile>(u => u.UserProfile)
            .ThenInclude(p => p.IdLocationNavigation)
            .ThenInclude(l => l.IdProvinceNavigation)
            .AsNoTracking()
            .ToListAsync();
        return user;
    }

    public async Task<UserEco> UserById(int id)
    {
        IEnumerable<UserEco> list = await ListSelectUser();
        UserEco? user = list.SingleOrDefault(x => x.Id == id);
        return user!;
    }
}
