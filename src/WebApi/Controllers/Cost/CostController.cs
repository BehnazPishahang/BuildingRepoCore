using Building.ServiceModel.Cost;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Cost;

public class CostController : BaseController<CostRequest, CostResponse>
{
    public CostController() 
    {
        
    }

    protected override Task<CostResponse> GetById(CostRequest request)
    {
        throw new NotImplementedException();
    }

    protected override Task<CostResponse> GetAll()
    {
        throw new NotImplementedException();
    }
}