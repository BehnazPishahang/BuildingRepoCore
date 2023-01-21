using Application.Common;
using Application.ObjectState;
using Application.UnitOfWork;
using Building.Core.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Persistence;
using ServiceModel.ObjectState;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.ObjectState;

public class ObjectStateController : BaseController<ObjectStateRequest, ObjectStateResponse>
{
    private readonly AppConfiguration _appConfiguration;
    private readonly IUnitOfWork _unitOfWork;

    public ObjectStateController(IObjectStateRepository objectStateRepository, IOptions<AppConfiguration> options, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _appConfiguration = options.Value;
    }

    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateResponse> GetById([FromBody] ObjectStateRequest request)
    {
        
        var theObjectStateType = await _unitOfWork.Repositorey<IGenericRepository<Domain.ObjectState.ObjectState>>().GetById(request.theObjectStateContract.Id);
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
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateResponse> GetAll()
    {
        var theObjectStateList = await _unitOfWork.Repositorey<IGenericRepository<Domain.ObjectState.ObjectState>>().GetAll();

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