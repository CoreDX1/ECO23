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

    public async Task<IEnumerable<UserEco>> ListSelectUser()
    {
        IEnumerable<UserEco> fusion = await (
            from user in _context.UserEco
            join location in _context.UserLocation
                on user.UserProfile.IdLocation equals location.IdLocation
            join profile in _context.UserProfile on user.IdUser equals profile.IdUser
            join province in _context.Province on location.IdProvince equals province.IdProvince
            select new UserEco
            {
                IdUser = user.IdUser,
                Name = user.Name,
                PaternalLastName = user.PaternalLastName,
                MaternalLastName = user.MaternalLastName,
                CellPhone = user.CellPhone,
                UserPermissions = user.UserPermissions,
                UserProfile = new UserProfile
                {
                    IdUserProfile = profile.IdUserProfile,
                    IdLocation = location.IdLocation,
                    IdUser = profile.IdUser,
                    Email = profile.Email,
                    UserPassword = profile.UserPassword,
                    CreationDate = profile.CreationDate,
                    IdLocationNavigation = new UserLocation
                    {
                        Street = location.Street,
                        HouseNumber = location.HouseNumber,
                        IdProvince = location.IdProvince,
                        IdProvinceNavigation = new Province
                        {
                            IdProvince = location.IdProvince,
                            Name = province.Name
                        }
                    }
                }
            }
        ).AsNoTracking().ToListAsync();

        return fusion;
    }

    public async Task<UserEco> UserById(int id)
    {
        IEnumerable<UserEco> list = await ListSelectUser();
        UserEco? user = list.SingleOrDefault(x => x.IdUser == id);
        return user!;
    }

    public async Task<bool> CreateUserEco(UserEco userEco)
    {
        await isValidateEmail(userEco);
        await _context.UserEco.AddAsync(userEco);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<bool> isValidateEmail(UserEco data)
    {
        bool user = await _context.UserEco
            .Where(x => x.UserProfile.Email.Equals(data.UserProfile.Email))
            .AnyAsync();

        return user;
    }

    public Task<bool> UpdateUserEco(UserEco userEco)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserEco(int id)
    {
        throw new NotImplementedException();
    }
}
