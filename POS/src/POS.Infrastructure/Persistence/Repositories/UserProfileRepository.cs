using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly Eco23Context _context;

    public UserProfileRepository(Eco23Context context)
    {
        _context = context;
    }

    public async Task<bool> CreateUserProfile(
        UserProfile addProfile,
        short idLocation,
        short idUser
    )
    {
        addProfile.IdLocation = idLocation;
        addProfile.IdUser = idUser;
        addProfile.CreationDate = DateTime.Now;
        await _context.UserProfile.AddAsync(addProfile);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<UserProfile> isValidateEmail(string email)
    {
        var isMail = await _context.UserProfile
            .Where(x => x.Email.Equals(email))
            .SingleOrDefaultAsync();
        return isMail!;
    }
}
