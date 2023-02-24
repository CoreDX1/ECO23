using POS.Domain.Entities;
using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserLocationRepository
{
    Task<bool> CreateUserLocation(UserComplete userLocation);
}
