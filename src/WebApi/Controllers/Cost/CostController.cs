using Application.Cost;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Cost;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Cost;

public class CostController : BaseController<CostContract>
{
    private readonly ICostRepository _costRepository;
    public CostController(ICostRepository costRepository)
    {
        _costRepository = costRepository;
    }
    
    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostContract> GetById(CostContract request)
    {
        var theCost = await _costRepository.GetById(request.Id);

        return new CostContract()
        {
            Amount = theCost.Amount,
            CashAmount = theCost.CashAmount,
            EventDate = theCost.EventDate,
            FromDate = theCost.FromDate,
            ToDate = theCost.ToDate,
            TheBuilding = theCost.TheBuilding,
            TheCostType = theCost.TheCostType,
            TheObjectState = theCost.TheObjectState,
        };
    }
    
    [HttpGet]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<List<CostContract>> GetAll()
    {
        var theCostList = await _costRepository.GetAll();

        return theCostList.Select(x => new CostContract()
        {
            Amount = x.Amount,
            CashAmount = x.CashAmount,
            EventDate = x.EventDate,
            FromDate = x.FromDate,
            ToDate = x.ToDate,
            TheBuilding = x.TheBuilding,
            TheCostType = x.TheCostType,
            TheObjectState = x.TheObjectState,
        }).ToList();
    }
}