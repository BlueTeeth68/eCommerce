using Application.Interfaces.IRepositories;

namespace Application;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository UserRepository { get; set; }
    
    public Task<int> SaveChangeAsync();

    public Task BeginTransactionAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}