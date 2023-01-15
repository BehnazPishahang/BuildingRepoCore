using Application.ObjectState;
using Building.Core.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Persistence;
using ServiceModel.ObjectState;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.ObjectState;

public class ObjectStateController : BaseController<ObjectStateRequest, ObjectStateResponse>
{
    private readonly IObjectStateRepository _objectStateRepository;
    private readonly AppConfiguration _appConfiguration;

    public ObjectStateController(IObjectStateRepository objectStateRepository, IOptions<AppConfiguration> options)
    {
        _objectStateRepository = objectStateRepository;
        _appConfiguration = options.Value;
    }
    
    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateResponse> GetById([FromBody] ObjectStateRequest request)
    {
        
        var theObjectStateType = await _objectStateRepository.GetById(request.theObjectStateContract.Id);
        
        return new ObjectStateResponse()
        {
            theObjectStateContractList = new List<ObjectStateContract>()
            {
                new ObjectStateContract()
                {
                    Code = theObjectStateType.Code,
                    Title = theObjectStateType.Title
                }
            },
        };
    }

    [HttpGet]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateResponse> GetAll()
    {
        var theObjectStateList = await _objectStateRepository.GetAll();

        return new ObjectStateResponse()
        {
            theObjectStateContractList = theObjectStateList.Select(x => new ObjectStateContract()
            {
                Code = x.Code,
                Title = x.Title
            }).ToList()
        } ;
    }
}