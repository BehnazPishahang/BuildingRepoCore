using Application.Common;
using Application.Cost;
using Persistence;

namespace Application.ObjectState;

public class ObjectStateRepository : GenericRepository<Domain.ObjectState.ObjectState>, IObjectStateRepository
{
    public ObjectStateRepository(DataContext context) : base(context)
    {

    }
}