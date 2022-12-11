using Application.Building;
using Persistence;
using ServiceModel.Building;
using WebApi.Controllers.BaseController;

namespace WebApi.Controllers.Building
{
    public class BuildingController : BaseController<BuildingRequest, BuildingResponse>
    {
        private readonly BuildingRepository _buildingRepository;

        public BuildingController(BuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }


        public override Task<BuildingResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<BuildingResponse> GetById(BuildingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
