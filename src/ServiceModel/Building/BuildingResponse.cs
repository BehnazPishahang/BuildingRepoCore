using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Building
{
    public class BuildingResponse
    {
        public BuildingResponse()
        {
            this.theBuildingContractList = new List<BuildingContract>();
        }

        public List<BuildingContract> theBuildingContractList { get; set; }
    }
}
