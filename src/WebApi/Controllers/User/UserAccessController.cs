using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.User;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.User;

public class UserAccessController : BaseController<UserAccessRequest, UserAccessResponse>
{
    private readonly IUserAccessRepository _userAccessRepository;

    public UserAccessController(IUserAccessRepository userAccessRepository)
    {
        _userAccessRepository = userAccessRepository;
    }
    
    [HttpPost]
    [Authorize]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessResponse> GetById([FromBody] UserAccessRequest request)
    {
        var theUserAccess = await _userAccessRepository.GetById(request.theUserAccessContract.Id);
        
        return new UserAccessResponse()
        {
            theUserAccessContractList = new List<UserAccessContract>
            {
                new UserAccessContract()
                {
                    SignText = theUserAccess.SignText,
                    StartDate = theUserAccess.StartDate,
                    EndDate = theUserAccess.EndDate,
                    UserId = theUserAccess.UserId,
                    UserAccessTypeId = theUserAccess.UserAccessTypeId,
                }
            },
        };
    }

    [HttpGet]
    [Authorize]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessResponse> GetAll()
    {
        var theUserAccessList = await _userAccessRepository.GetAll();
        
        return new UserAccessResponse()
        {
            theUserAccessContractList = theUserAccessList.Select(theUserAccess => new UserAccessContract()
            {
                SignText = theUserAccess.SignText,
                StartDate = theUserAccess.StartDate,
                EndDate = theUserAccess.EndDate,
                UserId = theUserAccess.UserId,
                UserAccessTypeId = theUserAccess.UserAccessTypeId,
            }).ToList(),
        };
    }
}