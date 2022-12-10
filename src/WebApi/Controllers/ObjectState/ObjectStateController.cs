using Application.ObjectState;
using Controllers.ObjectState;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.ObjectState;

public class ObjectStateController : BaseController<ObjectStateContract>
{
    private readonly IObjectStateRepository _objectStateRepository; 
    public ObjectStateController(IObjectStateRepository objectStateRepository)
    {
        _objectStateRepository = objectStateRepository;
    }
    
    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateContract> GetById(ObjectStateContract request)
    {
        var theObjectStateType = await _objectStateRepository.GetById(request.Id);
        
        return new ObjectStateContract()
        {
            Code = theObjectStateType.Code,
            Title = theObjectStateType.Title
        };
    }

    [HttpGet]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<List<ObjectStateContract>> GetAll()
    {
        var theObjectStateList = await _objectStateRepository.GetAll();

        return theObjectStateList.Select(x => new ObjectStateContract()
        {
            Code = x.Code,
            Title = x.Title
        }).ToList();
    }
}