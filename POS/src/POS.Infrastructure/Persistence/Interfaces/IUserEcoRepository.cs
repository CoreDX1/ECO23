using POS.Domain.Entities;
using POS.Infrastructure.Persistence.Interfaces.GenericRepository;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserEcoRepository : IGenericRepository<UserEco>
{
    public Task<IEnumerable<UserEco>> ListSelectUser();
    public Task<UserEco> UserById(short id);
}
