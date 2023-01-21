using Application.Common;
using Application.Cost;
using Application.UnitOfWork;
using Domain.Cost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Cost;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.Cost;


public class CostTypeController : BaseController<CostTypeRequest, CostTypeResponse>
{

    private readonly IUnitOfWork _unitOfWork;

    public CostTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostTypeResponse> GetById([FromBody] CostTypeRequest request)
    {
        var theCostType = await _unitOfWork.Repositorey<IGenericRepository<Domain.Cost.CostType>>().GetById(request.theCostTypeContract.Id);

        return new CostTypeResponse()
        {
            theCostTypeContractList = new()
            {
                new CostTypeContract()
                {
                    Code = theCostType.Code,
                    Title = theCostType.Title
                }
            }
            
        };
    }

    [HttpGet]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostTypeResponse> GetAll()
    {
        var theCostTypeList = await _unitOfWork.Repositorey<IGenericRepository<Domain.Cost.CostType>>().GetAll();

        return new CostTypeResponse()
        {
            theCostTypeContractList = theCostTypeList.Select(x => new CostTypeContract()
            {
                Code = x.Code,
                Title = x.Title
            }).ToList()
        };
    }
}