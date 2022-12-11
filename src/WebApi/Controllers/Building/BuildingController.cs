using Application.Building;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using ServiceModel.Building;
using ServiceModel.Cost;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Building
{
    public class BuildingController : BaseController<BuildingRequest, BuildingResponse>
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }


        [HttpGet]
        [Route("api/v1/[controller]/[action]")]
        public override async Task<BuildingResponse> GetById(BuildingRequest request)
        {
            var Onebuilding = await _buildingRepository.GetById(request.theBuildingContract.Id);
            return new BuildingResponse()
            {
                theBuildingContractList = new List<BuildingContract>()
                {
                    new BuildingContract()
                    {
                        Address = Onebuilding.Address,
                        Plaque = Onebuilding.Plaque,
                        Title = Onebuilding.Title,
                        CityName = Onebuilding.CityName,
                        FloorCount = Onebuilding.FloorCount
                    }
                }
            };
        }

        [HttpGet]
        [Route("api/v1/[controller]/[action]")]
        public override async Task<BuildingResponse> GetAll()
        {
            var theBuildingList = await _buildingRepository.GetAll();

            return new BuildingResponse()
            {
                theBuildingContractList = theBuildingList.Select(x => new BuildingContract()
                {
                    Address = x.Address,
                    Plaque = x.Plaque,
                    Title = x.Title,
                    CityName = x.CityName,
                    FloorCount = x.FloorCount,
                }).ToList()
            };
        }

        [HttpGet]
        [Route("api/v1/[controller]/[action]")]
        public async Task<BuildingResponse> GetbyCityName(BuildingRequest request)
        {
            var Thebuilding = await _buildingRepository.GetbyCityName(request.theBuildingContract.CityName);
            return new BuildingResponse()
            {
                theBuildingContractList = Thebuilding.Select(Onebuilding => new BuildingContract()
                {
                    Address = Onebuilding.Address,
                    Plaque = Onebuilding.Plaque,
                    Title = Onebuilding.Title,
                    CityName = Onebuilding.CityName,
                    FloorCount = Onebuilding.FloorCount
                }).ToList()
            };
        }
    }
}