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

    public async Task<bool> CreateUserLocation(UserComplete userLocation)
    {
        var location = new UserLocation
        {
            Street = userLocation.Street!,
            HouseNumber = userLocation.HouseNumber,
            IdProvince = userLocation.IdProvince,
        };
        await _context.UserLocation.AddAsync(location);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
