using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Building
{
    public class BuildingRequest
    {
        public BuildingRequest()
        {
            this.theBuildingContract = new BuildingContract();
        }
        public BuildingContract theBuildingContract { get; set; }
    }
    
  
}
