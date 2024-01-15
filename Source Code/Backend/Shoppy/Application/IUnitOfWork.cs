namespace Application;

public interface IUnitOfWork : IDisposable
{
    public Task<int> SaveChangeAsync();

    public Task BeginTransactionAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}