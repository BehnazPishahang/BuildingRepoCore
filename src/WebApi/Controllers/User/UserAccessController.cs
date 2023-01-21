using Application.Common;
using Application.UnitOfWork;
using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.User;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.User;

public class UserAccessController : BaseController<UserAccessRequest, UserAccessResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserAccessController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessResponse> GetById([FromBody] UserAccessRequest request)
    {
        var theUserAccess = await _unitOfWork.Repositorey<IGenericRepository<Domain.User.UserAccess>>().GetById(request.theUserAccessContract.Id);
        
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
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessResponse> GetAll()
    {
        var theUserAccessList = await _unitOfWork.Repositorey<IGenericRepository<Domain.User.UserAccess>>().GetAll();
        
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