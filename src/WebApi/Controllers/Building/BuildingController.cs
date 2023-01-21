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

namespace WebApi.Controllers.Building
{
    public class BuildingController : BaseController<BuildingRequest, BuildingResponse>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IObjectStateRepository _objectStateRepository;

        public BuildingController(IBuildingRepository buildingRepository, IObjectStateRepository objectStateRepository)
        {
            _buildingRepository = buildingRepository;
            _objectStateRepository = objectStateRepository;
        }


        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public override async Task<BuildingResponse> GetById([FromBody] BuildingRequest request)
        {


            var Onebuilding = await _buildingRepository.GetById(request.theBuildingContract.Id);

            return new BuildingResponse()
            {
                theBuildingContractList = new List<ServiceModel.Building.Building>()
                {
                    new ServiceModel.Building.Building()
                    {

                        Address = Onebuilding.Address,
                        Plaque = Onebuilding.Plaque,
                        Title = Onebuilding.Title,
                        CityName = Onebuilding.CityName,
                        FloorCount = Onebuilding.FloorCount,
                        TheCostList = Onebuilding.TheCostList.Select(cost => new CostContract()
                        {
                           Amount = cost.Amount,
                        }).ToList(),
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
            var theBuildingList = await _buildingRepository.GetAll();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new Building()
                {
                    Address = x.Address,
                    Plaque = x.Plaque,
                    Title = x.Title,
                    CityName = x.CityName,
                    FloorCount = x.FloorCount,
                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetbyCityName([FromBody] BuildingRequest request)
        {
            var Thebuilding = await _buildingRepository.GetbyCityName(request.theBuildingContract.CityName);

            return new BuildingResponse()
            {
                theBuildingContractList = Thebuilding.Select(Onebuilding => new Building()
                {
                    Address = Onebuilding.Address,
                    Plaque = Onebuilding.Plaque,
                    Title = Onebuilding.Title,
                    CityName = Onebuilding.CityName,
                    FloorCount = Onebuilding.FloorCount
                }).ToList()
            };
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ActionFilterModelStateValidation))]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetBuildingEager()
        {
            var theBuildingList = await _buildingRepository.GetBuildingEager();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new Building()
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
            var theBuildingList = _buildingRepository.GetBuildingExplicit();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new Building()
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
            var theBuildingList = _buildingRepository.GetBuildingSelectLoading();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new Building()
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

            ServiceModel.Building.Building Onebuilding = new ServiceModel.Building.Building
            {
                Address = request.theBuildingContract.Address,
                CityName = request.theBuildingContract.CityName,
                FloorCount = request.theBuildingContract.FloorCount,
                Plaque = request.theBuildingContract.Plaque,
                Title = request.theBuildingContract.Title,
                TheCostList = request.theBuildingContract.TheCostList.Select(cost => new CostContract()
                {
                    TheObjectState = new ServiceModel.ObjectState.ObjectStateContract
                    {
                        //Code = "",
                        //Code = "",
                        //Code = "",

                    },
                    Amount = cost.Amount,
                    CashAmount = cost.CashAmount,
                    EventDate = cost.EventDate,
                    FromDate = cost.FromDate,
                    ToDate = cost.ToDate


                }).ToList()
            };
            string result = _buildingRepository.Add(Onebuilding);
            return result;

        }
    }
}