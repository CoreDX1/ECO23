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

    public async Task<bool> CreateUserProfile(UserProfile addProfile)
    {
        await _context.UserProfile.AddAsync(addProfile);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
