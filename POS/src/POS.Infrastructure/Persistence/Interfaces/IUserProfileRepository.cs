using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces.GenericRepository;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserProfileRepository : IGenericRepository<UserProfile>
{
    Task<bool> IsValidateEmail(string email);
}
