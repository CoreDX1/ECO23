using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserEcoRepository
{
    public Task<IEnumerable<UserEco>> ListSelectUser();
    public Task<UserEco> UserById(int id);
    public Task<bool> UpdateUserEco(UserEco userEco);
    public Task<bool> DeleteUserEco(int id);
    public Task<bool> CreateUserEco(UserEco userEco);
}
