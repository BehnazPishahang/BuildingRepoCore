using Application.Common;

namespace Application.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
    TRepository Repositorey<TRepository>() where TRepository : IGenericRepository;
}