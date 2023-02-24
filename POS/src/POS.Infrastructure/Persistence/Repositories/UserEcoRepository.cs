using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;

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
        UserEco? user = list.SingleOrDefault(x => x.IdUser == id);
        return user!;
    }

    public async Task<bool> CreateUserEco(UserComplete userComplete)
    {
        await isValidateEmail(userComplete.Email!);
        var user = new UserEco
        {
            Name = userComplete.Name!,
            PaternalLastName = userComplete.PaternalLastName!,
            MaternalLastName = userComplete.MaternalLastName!,
            CellPhone = userComplete.CellPhone!,
        };
        await _context.UserEco.AddAsync(user);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    private async Task<bool> isValidateEmail(string email)
    {
        bool user = await _context.UserProfile.Where(x => x.Email.Equals(email)).AnyAsync();

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
