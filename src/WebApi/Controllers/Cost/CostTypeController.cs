using Building.ServiceModel.Cost;
using Domain.Cost;
using Persistence;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Cost;


public class CostTypeController : BaseController<CostTypeRequest, CostTypeResponse>
{
    public CostTypeController(DataContext context) : base(context)
    {
    }

    protected override Task<CostTypeResponse> GetById(CostTypeRequest request)
    {
        throw new NotImplementedException();
    }

    protected override Task<CostTypeResponse> GetAll()
    {
        throw new NotImplementedException();
    }
}