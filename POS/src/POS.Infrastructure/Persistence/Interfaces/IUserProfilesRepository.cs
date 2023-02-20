using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserProfilesRepository
{
    Task<IEnumerable<UserProfile>> ListSelectUserProfile();
}
