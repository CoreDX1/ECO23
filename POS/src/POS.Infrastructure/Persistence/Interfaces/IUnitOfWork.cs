namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserEcoRepository UserEco { get; }
    IUserProfilesRepository UserProfiles { get; }
    void SaveChanges();
    Task SaveChangesAsync();
}
