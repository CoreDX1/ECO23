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
            .Include(e => e.UserPermissions)
            .Include(u => u.UserProfile.IdLocationNavigation.IdProvinceNavigation)
            .AsNoTracking()
            .ToListAsync();
        return user;
    }

    public async Task<UserEco> UserById(short id)
    {
        UserEco? user = await _context.UserEco
            .AsNoTracking()
            .Include(e => e.UserPermissions)
            .Include(u => u.UserProfile.IdLocationNavigation.IdProvinceNavigation)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        return user!;
    }
}
