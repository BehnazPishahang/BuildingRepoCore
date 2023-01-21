using Application.Common;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dbContext;
    private readonly IServiceProvider _serviceProvider;
    public UnitOfWork(DataContext dbContext, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
    }
    
    public void Commit() => _dbContext.SaveChanges();


    public async Task CommitAsync() => await _dbContext.SaveChangesAsync();


    public void Rollback() => _dbContext.Dispose();


    public async Task RollbackAsync() => await _dbContext.DisposeAsync();
    
    public TRepository? Repositorey<TRepository>() where TRepository : IGenericRepository
    {
        if (!typeof(TRepository).IsInterface)
        {
            throw new ArgumentException("TRepository Is Not Valid Type");
        }

        return (TRepository)_serviceProvider.GetService(typeof(TRepository));
    }
}