using Application.Common;
using Application.ObjectState;
using Application.UnitOfWork;
using AutoMapper;
using Building.Core.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Persistence;
using ServiceModel.ObjectState;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi.Controllers.ObjectState;

public class ObjectStateController : BaseController<ObjectStateRequest, ObjectStateResponse>
{
    private readonly AppConfiguration _appConfiguration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDistributedCache _cache;
    private readonly IMapper _mapper;

    public ObjectStateController(IObjectStateRepository objectStateRepository, IOptions<AppConfiguration> options, IUnitOfWork unitOfWork, IDistributedCache cache, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
        _mapper = mapper;
        _appConfiguration = options.Value;
    }

    [HttpPost]
    [Authorize]
    [ServiceFilter(typeof(ActionFilterModelStateValidation))]
    [Route("api/v1/[controller]/[action]")]
    public override async Task<ObjectStateResponse> GetById([FromBody] ObjectStateRequest request)
    {
        var cacheResult = await _cache.GetStringAsync(request.theObjectStateContract.Id.ToString());
        if (cacheResult != null)
        {
            return new ObjectStateResponse()
            {
                theObjectStateContractList = JsonConvert.DeserializeObject<List<ObjectStateContract>>(cacheResult) 
            };
        }

        var theObjectStateType = await _unitOfWork.Repositorey<IGenericRepository<Domain.ObjectState.ObjectState>>().GetById(request.theObjectStateContract.Id);
        var resultList = new List<ObjectStateContract>()
        {
            new ()
            {
                Code = theObjectStateType.Code,
                Title = theObjectStateType.Title
            }
        };

        await _cache.SetStringAsync(request.theObjectStateContract.Id.ToString(), JsonConvert.SerializeObject(resultList), new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(30),
        });

        return new ObjectStateResponse()
        {
            theObjectStateContractList = resultList
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
            theObjectStateContractList = _mapper.Map<List<ObjectStateContract>>(theObjectStateList)
        };
    }
}