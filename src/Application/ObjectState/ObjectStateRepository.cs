using Application.Common;
using Application.Cost;
using Persistence;

namespace Application.ObjectState;

public class ObjectStateRepository : GenericRepository<Domain.ObjectState.ObjectState>, IObjectStateRepository
{
    public ObjectStateRepository(DataContext context) : base(context)
    {

    }

    public Domain.ObjectState.ObjectState GetbyCode(string Code)
    {
        return _context.Set<Domain.ObjectState.ObjectState>().Where(a => a.Code == Code).FirstOrDefault();


    }
}