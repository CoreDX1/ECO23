using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly Eco23Context _context;

    public UserProfileRepository(Eco23Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserProfile(UserComplete userProfile)
    {
        short user = (
            from n in _context.UserEco
            where n.Name == userProfile.Name && n.CellPhone == userProfile.CellPhone
            select n.IdUser
        ).FirstOrDefault();

        short location = (
            from n in _context.UserLocation
            where n.Street == userProfile.Street && n.HouseNumber == userProfile.HouseNumber
            select n.IdLocation
        ).FirstOrDefault();

        var profile = new UserProfile
        {
            Email = userProfile.Email!,
            UserPassword = userProfile.UserPassword!,
            CreationDate = DateTime.Now,
            IdUser = user,
            IdLocation = location,
        };
        await _context.UserProfile.AddAsync(profile);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
