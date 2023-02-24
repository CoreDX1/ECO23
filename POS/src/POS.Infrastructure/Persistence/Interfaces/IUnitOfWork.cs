namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserEcoRepository UserEco { get; }
    IUserLocationRepository UserLocation { get; }
    IUserProfileRepository UserProfile { get; }
    void SaveChanges();
    Task SaveChangesAsync();
}
