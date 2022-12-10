using Application.Cost;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Building;
using ServiceModel.Cost;
using ServiceModel.ObjectState;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Cost;

public class CostController : BaseController<CostRequest, CostResponse>
{
    private readonly ICostRepository _costRepository;

    public CostController(ICostRepository costRepository)
    {
        _costRepository = costRepository;
    }

    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostResponse> GetById(CostRequest request)
    {
        var theCost = await _costRepository.GetById(request.theCostContract.Id);

        return new CostResponse()
        {
            theCostContractList = new List<CostContract>()
            {
                new CostContract()
                {
                    Amount = theCost.Amount,
                    CashAmount = theCost.CashAmount,
                    EventDate = theCost.EventDate,
                    FromDate = theCost.FromDate,
                    ToDate = theCost.ToDate,
                    TheBuilding = null,
                    TheCostType = null,
                    TheObjectState = null,
                }
            }
        };
    }

    [HttpGet]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostResponse> GetAll()
    {
        var theCostList = await _costRepository.GetAll();

        return new CostResponse()
        {
            theCostContractList = theCostList.Select(x => new CostContract()
            {
                Amount = x.Amount,
                CashAmount = x.CashAmount,
                EventDate = x.EventDate,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                TheBuilding = null,
                TheCostType = null,
                TheObjectState = null,
            }).ToList()
        };
    }
}