using Application.ObjectState;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.ObjectState;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.ObjectState;

public class ObjectStateController : BaseController<ObjectStateRequest, ObjectStateResponse>
{
    private readonly IObjectStateRepository _objectStateRepository; 
    public ObjectStateController(IObjectStateRepository objectStateRepository)
    {
        _objectStateRepository = objectStateRepository;
    }
    
    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateResponse> GetById(ObjectStateRequest request)
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