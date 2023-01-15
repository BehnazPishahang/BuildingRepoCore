using Application.User;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.User;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.User;

public class UserAccessTypeController : BaseController<UserAccessTypeRequest, UserAccessTypeResponse>
{
    private readonly IUserAccessTypeRepository _userAccessTypeRepository;

    public UserAccessTypeController(IUserAccessTypeRepository userAccessTypeRepository)
    {
        _userAccessTypeRepository = userAccessTypeRepository;
    }
    
    [HttpPost]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessTypeResponse> GetById([FromBody] UserAccessTypeRequest request)
    {
        var theUserAccessType = await _userAccessTypeRepository.GetById(request.theUserAccessTypeContract.Id);
        
        return new UserAccessTypeResponse()
        {
            theUserAccessTypeContractList = new List<UserAccessTypeContract>
            {
                new UserAccessTypeContract()
                {
                    Code = theUserAccessType.Code,
                    Title = theUserAccessType.Title,
                    State = theUserAccessType.State,
                }
            },
        };
    }

    [HttpGet]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessTypeResponse> GetAll()
    {
        var theUserAccessTypeList = await _userAccessTypeRepository.GetAll();
        
        return new UserAccessTypeResponse()
        {
            theUserAccessTypeContractList = theUserAccessTypeList.Select(theUserAccessType => new UserAccessTypeContract()
            {
                Code = theUserAccessType.Code,
                Title = theUserAccessType.Title,
                State = theUserAccessType.State,
            }).ToList(),
        };
    }
}