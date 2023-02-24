using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserProfileRepository
{
    Task<bool> CreateUserProfile(UserComplete userProfile);
}
