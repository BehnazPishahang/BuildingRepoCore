using Application.Common;
using Persistence;

namespace Application.Cost;

public class CostRepository : GenericRepository<Domain.Cost.Cost>, ICostRepository
{
    public CostRepository(DataContext context) : base(context)
    {

    }
}