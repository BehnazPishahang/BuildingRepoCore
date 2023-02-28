using Commons.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Building
{
    public class BuildingResponse: ResponseMessage
    {
        public BuildingResponse()
        {
            this.theBuildingContractList = new List<BuildingContract>();
        }

        public Result Result { get; set; }
        public List<BuildingContract> theBuildingContractList { get; set; }
    }
}
