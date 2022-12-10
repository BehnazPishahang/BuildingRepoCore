using Application.Cost;
using Controllers.Cost;
using Domain.Cost;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Cost;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Cost;


public class CostTypeController : BaseController<CostTypeContract>
{
    private readonly ICostTypeRepository _costTypeRepository;
    public CostTypeController(ICostTypeRepository costTypeRepository)
    {
        _costTypeRepository = costTypeRepository;
    }

    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<CostTypeContract> GetById(CostTypeContract request)
    {
        var theCostType = await _costTypeRepository.GetById(request.Id);
        
        return new CostTypeContract()
        {
            Code = theCostType.Code,
            Title = theCostType.Title
        };
    }

    [HttpGet]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<List<CostTypeContract>> GetAll()
    {
        var theCostTypeList = await _costTypeRepository.GetAll();

        return theCostTypeList.Select(x => new CostTypeContract()
        {
            Code = x.Code,
            Title = x.Title
        }).ToList();
    }
}