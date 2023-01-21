using Application.Common;
using Application.Cost;
using Application.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Cost;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.Cost;

public class CostController : BaseController<CostRequest, CostResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CostController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostResponse> GetById([FromBody] CostRequest request)
    {
        var theCost = await _unitOfWork.Repositorey<IGenericRepository<Domain.Cost.Cost>>().GetById(request.theCostContract.Id);

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
                    BuildingId = theCost.BuildingId.ToString(),
                    CostTypeId = theCost.CostTypeId.ToString(),
                    ObjectStateId = theCost.ObjectStateId.ToString(),
                }
            }
        };
    }

    [HttpGet]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostResponse> GetAll()
    {
        var theCostList = await _unitOfWork.Repositorey<IGenericRepository<Domain.Cost.Cost>>().GetAll();

        return new CostResponse()
        {
            theCostContractList = theCostList.Select(x => new CostContract()
            {
                Amount = x.Amount,
                CashAmount = x.CashAmount,
                EventDate = x.EventDate,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                BuildingId = x.BuildingId.ToString(),
                CostTypeId = x.CostTypeId.ToString(),
                ObjectStateId = x.ObjectStateId.ToString(),
            }).ToList()
        };
    }
    
    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public async Task<CostResponse> GetByDate([FromBody] GetByDateRequest request)
    {
        var theCostList = await _unitOfWork.Repositorey<ICostRepository>().GetByDate(request.date);

        return new CostResponse()
        {
            theCostContractList = theCostList.Select(x => new CostContract()
            {
                Amount = x.Amount,
                CashAmount = x.CashAmount,
                EventDate = x.EventDate,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                BuildingId = x.BuildingId.ToString(),
                CostTypeId = x.CostTypeId.ToString(),
                ObjectStateId = x.ObjectStateId.ToString(),
            }).ToList()
        };
    }
}