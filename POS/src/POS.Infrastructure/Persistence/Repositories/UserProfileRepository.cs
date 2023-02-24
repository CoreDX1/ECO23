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
        if (!ValidateUser(userProfile))
            return false;

        var (userId, locationId) = GetIdUserLocation(userProfile);
        var profile = new UserProfile
        {
            Email = userProfile.Email!,
            UserPassword = userProfile.UserPassword!,
            CreationDate = DateTime.Now,
            IdUser = userId,
            IdLocation = locationId,
        };
        await _context.UserProfile.AddAsync(profile);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    private (short, short) GetIdUserLocation(UserComplete user)
    {
        short idUser = (
            from n in _context.UserEco
            where n.Name == user.Name && n.CellPhone == user.CellPhone
            select n.IdUser
        ).FirstOrDefault();

        short idLocation = (
            from n in _context.UserLocation
            where n.Street == user.Street && n.HouseNumber == user.HouseNumber
            select n.IdLocation
        ).FirstOrDefault();
        return (idUser, idLocation);
    }

    private bool ValidateUser(UserComplete user)
    {
        if (user.UserPassword != user.ReplyPassword)
            return false;
        return true;
    }
}
