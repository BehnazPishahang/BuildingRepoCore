using Application.Common;
using Persistence;

namespace Application.Cost;

public class CostTypeRepository: GenericRepository<Domain.Cost.CostType>, ICostTypeRepository
{
    public CostTypeRepository(DataContext context) : base(context)
    {

    }
}