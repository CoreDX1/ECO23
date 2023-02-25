using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Repositories;

public class UserLocationRepository : IUserLocationRepository
{
    private readonly Eco23Context _context;

    public UserLocationRepository(Eco23Context context)
    {
        _context = context;
    }

    public async Task<short> CreateUserLocation(UserLocation addLocation)
    {
        await _context.UserLocation.AddAsync(addLocation);
        var result = await _context.SaveChangesAsync();
        return addLocation.IdLocation;
    }
}
