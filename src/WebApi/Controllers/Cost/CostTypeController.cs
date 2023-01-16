using Application.Cost;
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

    private readonly ICostTypeRepository _costTypeRepository;
    public CostTypeController(ICostTypeRepository costTypeRepository)
    {
        _costTypeRepository = costTypeRepository;
    }

    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostTypeResponse> GetById([FromBody] CostTypeRequest request)
    {
        var theCostType = await _costTypeRepository.GetById(request.theCostTypeContract.Id);

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
        var theCostTypeList = await _costTypeRepository.GetAll();

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