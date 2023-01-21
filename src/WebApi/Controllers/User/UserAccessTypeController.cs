using Application.Common;
using Application.UnitOfWork;
using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.User;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.User;

public class UserAccessTypeController : BaseController<UserAccessTypeRequest, UserAccessTypeResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserAccessTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessTypeResponse> GetById([FromBody] UserAccessTypeRequest request)
    {
        var theUserAccessType = await _unitOfWork.Repositorey<IGenericRepository<Domain.User.UserAccessType>>().GetById(request.theUserAccessTypeContract.Id);
        
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
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserAccessTypeResponse> GetAll()
    {
        var theUserAccessTypeList = await _unitOfWork.Repositorey<IGenericRepository<Domain.User.UserAccessType>>().GetAll();
        
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