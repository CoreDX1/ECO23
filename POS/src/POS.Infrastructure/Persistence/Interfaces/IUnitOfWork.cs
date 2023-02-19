namespace POS.Infrastructure.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserEcoRepository UserEco { get; }
    void SaveChanges();
    Task SaveChangesAsync();
}
