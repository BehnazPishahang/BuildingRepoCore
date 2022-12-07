using Application.Common;
using Persistence;

namespace Application.Cost;

public class CostTypeRepository: GenericRepository<Domain.Cost.Cost>, ICostRepository
{
    public CostTypeRepository(DataContext context) : base(context)
    {

    }
}