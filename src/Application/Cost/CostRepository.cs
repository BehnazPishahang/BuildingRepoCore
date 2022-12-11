using Application.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;
using Commons.Extensions;
using Microsoft.VisualBasic;

namespace Application.Cost;

public class CostRepository : GenericRepository<Domain.Cost.Cost>, ICostRepository
{
    public CostRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Domain.Cost.Cost>> GetByDate(string date)
    {
        return _context.Costs.ToList().Where(x => x.ToDate!.GreaterThanEqual(date) &&
                                                                 x.FromDate!.LessThanEqual(date)).ToList();
    }
}