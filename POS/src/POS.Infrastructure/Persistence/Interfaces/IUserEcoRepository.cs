using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserEcoRepository
{
    public Task<dynamic> ListSelectUser();
}
