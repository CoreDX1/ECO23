using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Infrastructure.Persistence.Repositories.GenericRepository;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
{
    private readonly Eco23Context _context;

    public UserProfileRepository(Eco23Context context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsValidateEmail(string email)
    {
        return await _context.UserProfile.AnyAsync(x => x.Email.Equals(email));
    }
}
