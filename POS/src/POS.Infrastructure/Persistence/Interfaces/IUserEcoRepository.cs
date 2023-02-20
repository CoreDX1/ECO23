using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserEcoRepository
{
    Task<IEnumerable<UserEco>> ListSelectUser();
}
