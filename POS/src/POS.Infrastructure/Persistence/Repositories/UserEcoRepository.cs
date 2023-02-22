using Microsoft.EntityFrameworkCore;
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

    public async Task<dynamic> ListSelectUser()
    {
        var fusion = await (
            from user in _context.UserEco
            // join profile in _context.UserProfile on user.IdUser equals profile.IdUser
            // join location in _context.UserLocation on profile.IdLocation equals location.IdLocation
            select new
            {
                user.IdUser,
                user.CellPhone,
                user.Name,
                user.UserPermissions,
                user.UserProfiles
            }
        ).AsNoTracking().ToListAsync();

        return fusion;
    }
}
