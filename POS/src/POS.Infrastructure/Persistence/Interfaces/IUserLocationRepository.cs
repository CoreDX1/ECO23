using POS.Domain.Entities;
using POS.Utilities.Static;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserLocationRepository
{
    Task<short> CreateUserLocation(UserLocation addLocation);
}
