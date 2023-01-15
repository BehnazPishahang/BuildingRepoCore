using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.User;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.User;

public class UserController : BaseController<UserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost]
    [Authorize]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserResponse> GetById([FromBody] UserRequest request)
    {
        var theUser = await _userRepository.GetById(request.theUserContract.Id);
        
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
    [Route("api/v1/[controller]/[action]")]
    public override async Task<UserResponse> GetAll()
    {
        var theUserList = await _userRepository.GetAll();
        
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