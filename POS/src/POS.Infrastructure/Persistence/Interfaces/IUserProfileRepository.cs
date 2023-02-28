using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserProfileRepository
{
    Task<bool> CreateUserProfile(UserProfile addProfile, short idLocation, short idUser);
    Task<UserProfile> isValidateEmail(string email);
}
