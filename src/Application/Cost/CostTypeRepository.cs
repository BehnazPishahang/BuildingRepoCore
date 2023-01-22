using Application.Common;
using Domain.Cost;
using Persistence;

namespace Application.Cost;

public class CostTypeRepository: GenericRepository<Domain.Cost.CostType>, ICostTypeRepository
{
    public CostTypeRepository(DataContext context) : base(context)
    {

    }

    public CostType GetbyCode(string Code)
    {
        return _context.Set<Domain.Cost.CostType>().Where(a => a.Code == Code).FirstOrDefault();
    }
}