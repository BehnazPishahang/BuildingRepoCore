using Application.Common;

namespace Application.Cost;

public interface ICostRepository:IGenericRepository<Domain.Cost.Cost>
{
    public Task<List<Domain.Cost.Cost>> GetByDate(string date);
}