using Application.Cost;
using Domain.Cost;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Cost;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Cost;


public class CostTypeController : BaseController<CostTypeRequest, CostTypeResponse>
{

    private readonly ICostTypeRepository _costTypeRepository;
    public CostTypeController(ICostTypeRepository costTypeRepository)
    {
        _costTypeRepository = costTypeRepository;
    }

    [HttpPost]
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