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
        IEnumerable<UserEco> user = await _context.UserEco
            .Include(u => u.UserProfile)
            .ThenInclude(p => p.IdLocationNavigation)
            .ThenInclude(l => l.IdProvinceNavigation)
            .AsNoTracking()
            .ToListAsync();

        return user;
    }

    public async Task<UserEco> UserById(int id)
    {
        IEnumerable<UserEco> list = await ListSelectUser();
        UserEco? user = list.SingleOrDefault(x => x.IdUser == id);
        return user!;
    }

    public async Task<bool> CreateUserEco(
        UserEco userEco,
        UserLocation userLocation,
        UserProfile userProfile
    )
    {
        await isValidateEmail(userEco);
        UserEco newUser = new UserEco
        {
            Name = userEco.Name,
            CellPhone = userEco.CellPhone,
            PaternalLastName = userEco.PaternalLastName,
            MaternalLastName = userEco.MaternalLastName,
            UserPermissions = userEco.UserPermissions
        };

        UserLocation newLocation = new UserLocation
        {
            Street = userLocation.Street,
            HouseNumber = userLocation.HouseNumber,
            IdProvince = userLocation.IdProvince, // INFO : Foreign Key de UserProvince
        };

        UserProfile newProfile = new UserProfile
        {
            Email = userProfile.Email,
            UserPassword = userProfile.UserPassword,
            CreationDate = DateTime.Now,
            IdLocation = newLocation.IdLocation, // INFO : Foreign Key de UserLocation
            IdUser = newUser.IdUser, // INFO : Foreign Key de UserProfile
        };

        await _context.UserEco.AddAsync(newUser);
        await _context.UserLocation.AddAsync(newLocation);
        await _context.UserProfile.AddAsync(newProfile);
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
