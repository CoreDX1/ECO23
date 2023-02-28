using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Infrastructure.Persistence.Repositories.GenericRepository;
using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserLocationRepository : GenericRepository<UserLocation>, IUserLocationRepository
{
    public UserLocationRepository(Eco23Context context) : base(context) { }
}
