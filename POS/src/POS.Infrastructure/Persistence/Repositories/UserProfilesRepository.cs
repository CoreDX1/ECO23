using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserProfilesRepository : IUserProfilesRepository
{
    private readonly Eco23Context _context;

    public UserProfilesRepository(Eco23Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserProfile>> ListSelectUserProfile()
    {
        IEnumerable<UserProfile> userProfiles = await _context.UserProfile
            .AsNoTracking()
            .ToListAsync();
        return userProfiles;
    }
}
