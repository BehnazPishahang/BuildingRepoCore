using Building.ServiceModel.ObjectState;
using Domain.ObjectState;
using Persistence;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.ObjectState;

public class ObjectStateController : BaseController<ObjectStateRequest, ObjectStateResponse> 
{
    public ObjectStateController(DataContext context) : base(context)
    {
    }

    protected override Task<ObjectStateResponse> GetById(ObjectStateRequest request)
    {
        throw new NotImplementedException();
    }

    protected override Task<ObjectStateResponse> GetAll()
    {
        throw new NotImplementedException();
    }
}