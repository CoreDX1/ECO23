using POS.Domain.Entities;
using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserEcoRepository
{
    public Task<IEnumerable<UserEco>> ListSelectUser();
    public Task<UserEco> UserById(int id);
    public Task<bool> UpdateUserEco(UserEco userEco);
    public Task<bool> DeleteUserEco(int id);
    public Task<short> CreateUserEco(UserEco addUser);
}
