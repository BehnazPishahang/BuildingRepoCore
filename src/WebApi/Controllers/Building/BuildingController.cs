using Application.Building;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Building;
using ServiceModel.Cost;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers.BaseController;
using static WebApi.Controllers.Authentication.AuthenticationController;
using Application.ObjectState;
using Application.UnitOfWork;
using Application.Cost;

namespace WebApi.Controllers.Building
{
    public class BuildingController : BaseController<BuildingRequest, BuildingResponse>
    {

        public IUnitOfWork _UnitOfWork { get; }

        public BuildingController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }


        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public override async Task<BuildingResponse> GetById([FromBody] BuildingRequest request)
        {


            var Onebuilding = await _UnitOfWork.Repositorey<IBuildingRepository>().GetById(request.theBuildingContract.Id);

            return new BuildingResponse()
            {
                theBuildingContractList = new List<ServiceModel.Building.BuildingContract>()
                {
                    new ServiceModel.Building.BuildingContract()
                    {

                        Address = Onebuilding.Address,
                        Plaque = Onebuilding.Plaque,
                        Title = Onebuilding.Title,
                        CityName = Onebuilding.CityName,
                        FloorCount = Onebuilding.FloorCount,
                         
                        TheBuildingHistory=new BuildingHistoryContract()
                    {
                        age=Onebuilding.TheBuildingHistory.age,
                        engineerName=Onebuilding.TheBuildingHistory.engineerName,
                        engineerFamily=Onebuilding.TheBuildingHistory.engineerFamily
                    },
                        TheCostList = Onebuilding.TheCostList?.Select(cost => new CostContract()
                        {
                           Amount = cost.Amount,
                        }).ToList()

                    }
                }
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public override async Task<BuildingResponse> GetAll()
        {

            //HMACSHA256 hmac = new HMACSHA256();
            //string key = Convert.ToBase64String(hmac.Key);
            var theBuildingList = await _UnitOfWork.Repositorey<IBuildingRepository>().GetAll();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new BuildingContract()
                {
                    Address = x.Address,
                    Plaque = x.Plaque,
                    Title = x.Title,
                    CityName = x.CityName,
                    FloorCount = x.FloorCount,
                    TheBuildingHistory = new()
                    {
                        age = x.TheBuildingHistory?.age,
                        engineerName = x.TheBuildingHistory?.engineerName,
                        engineerFamily = x.TheBuildingHistory?.engineerFamily
                    }
                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetbyCityName([FromBody] BuildingRequest request)
        {
            var Thebuilding = await _UnitOfWork.Repositorey<IBuildingRepository>().GetbyCityName(request.theBuildingContract.CityName);

            return new BuildingResponse()
            {
                theBuildingContractList = Thebuilding.Select(Onebuilding => new BuildingContract()
                {
                    Address = Onebuilding.Address,
                    Plaque = Onebuilding.Plaque,
                    Title = Onebuilding.Title,
                    CityName = Onebuilding.CityName,
                    FloorCount = Onebuilding.FloorCount,
                    TheBuildingRegion = new BuildingRegionContract()
                    {
                        region = Onebuilding.TheBuildingRegion?.region
                    }
                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetBuildingEager()
        {
            var theBuildingList = await _UnitOfWork.Repositorey<IBuildingRepository>().GetBuildingEager();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new BuildingContract()
                {
                    Address = x.Address,
                    Plaque = x.Plaque,
                    Title = x.Title,
                    CityName = x.CityName,
                    FloorCount = x.FloorCount,
                    TheCostList = x.TheCostList.Select(cost => new CostContract()
                    {
                        Amount = cost.Amount,
                        EventDate = cost.EventDate,
                        FromDate = cost.FromDate,
                        ToDate = cost.ToDate,
                        CashAmount = cost.CashAmount,

                    }).ToList()
                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetBuildingExplicit()
        {
            var theBuildingList = _UnitOfWork.Repositorey<IBuildingRepository>().GetBuildingExplicit();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new BuildingContract()
                {
                    Address = x.Address,
                    Plaque = x.Plaque,
                    Title = x.Title,
                    CityName = x.CityName,
                    FloorCount = x.FloorCount,
                    TheCostList = x.TheCostList.Select(cost => new CostContract()
                    {
                        Amount = cost.Amount,
                        EventDate = cost.EventDate,
                        FromDate = cost.FromDate,
                        ToDate = cost.ToDate,
                        CashAmount = cost.CashAmount,
                        TheCostType = new CostTypeContract
                        {
                            Code = cost.TheCostType.Code,
                            Title = cost.TheCostType.Title
                        }

                    }).ToList()
                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetBuildingSelectLoading()
        {
            var theBuildingList = _UnitOfWork.Repositorey<IBuildingRepository>().GetBuildingSelectLoading();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new BuildingContract()
                {
                    Title = x.Title,
                    CityName = x.CityName

                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public string AddBuilding([FromBody] BuildingRequest request)
        {

            Domain.Building.Building Onebuilding = new()
            {
                Address = request.theBuildingContract.Address,
                CityName = request.theBuildingContract.CityName,
                FloorCount = request.theBuildingContract.FloorCount,
                Plaque = request.theBuildingContract.Plaque,
                Title = request.theBuildingContract.Title,
                TheCostList = request.theBuildingContract.TheCostList.Select(cost => new Domain.Cost.Cost()
                {
                    TheObjectState = _UnitOfWork.Repositorey<IObjectStateRepository>().GetbyCode(cost.TheObjectState.Code),
                    TheCostType = _UnitOfWork.Repositorey<ICostTypeRepository>().GetbyCode(cost.TheCostType.Code),
                    Amount = cost.Amount,
                    CashAmount = cost.CashAmount,
                    EventDate = cost.EventDate,
                    FromDate = cost.FromDate,
                    ToDate = cost.ToDate


                }).ToList()
            };
            _UnitOfWork.Repositorey<IBuildingRepository>().Add(Onebuilding);
            _UnitOfWork.Commit();
            return "عملیات ثبت با موفقیت انجام شد";

        }
    }
}