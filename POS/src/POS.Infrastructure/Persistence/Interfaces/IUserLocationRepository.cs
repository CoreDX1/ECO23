using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUserLocationRepository
{
    Task<UserLocation> CreateUserLocation(UserLocation addLocation);
}
