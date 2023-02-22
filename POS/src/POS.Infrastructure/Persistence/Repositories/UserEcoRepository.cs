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

    public async Task<dynamic> ListSelectUser()
    {
        var fusion = await (
            from user in _context.UserEco
            join location in _context.UserLocation
                on user.UserProfile.IdLocation equals location.IdLocation
            join profile in _context.UserProfile on user.IdUser equals profile.IdUser
            join province in _context.Province on location.IdProvince equals province.IdProvince
            select new
            {
                user.IdUser,
                user.Name,
                user.PaternalLastName,
                user.MaternalLastName,
                user.CellPhone,
                user.UserPermissions,
                UserProfile = new
                {
                    profile.IdUser,
                    profile.Email,
                    profile.UserPassword,
                    profile.CreationDate,
                    location = new { location.Street, Province = location.IdProvinceNavigation }
                }
            }
        ).AsNoTracking().ToListAsync();

        return fusion;
    }
}
