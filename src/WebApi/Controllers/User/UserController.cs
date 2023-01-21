using Application.Common;
using Application.UnitOfWork;
using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.User;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.User;

public class UserController : BaseController<UserRequest, UserResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserResponse> GetById([FromBody] UserRequest request)
    {
        var theUser = await _unitOfWork.Repositorey<IGenericRepository<Domain.User.User>>().GetById(request.theUserContract.Id);
        
        return new UserResponse()
        {
            theUserContractList = new List<UserContract>
            {
                new UserContract()
                {
                    Name = theUser.Name,
                    Family = theUser.Family,
                    Sex = theUser.Sex,
                    StartDate = theUser.StartDate,
                    EndDate = theUser.EndDate,
                    MobileNumber = theUser.MobileNumber,
                    NationalCode = theUser.NationalCode
                }
            },
        };
    }

    [HttpGet]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserResponse> GetAll()
    {
        var theUserList = await _unitOfWork.Repositorey<IGenericRepository<Domain.User.User>>().GetAll();
        
        return new UserResponse()
        {
            theUserContractList = theUserList.Select(theUser => new UserContract()
            {
                Name = theUser.Name,
                Family = theUser.Family,
                Sex = theUser.Sex,
                StartDate = theUser.StartDate,
                EndDate = theUser.EndDate,
                MobileNumber = theUser.MobileNumber,
                NationalCode = theUser.NationalCode
            }).ToList(),
        };
    }
}