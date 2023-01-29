using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Building
{
    public class Building : BaseEntity
    {
        public string? Title { get; set; }

        public string? Address { get; set; }

        public int? FloorCount { get; set; }

        public int? Plaque { get; set; }

        public string? CityName { get; set; }

        [InverseProperty("TheBuilding")]
        public virtual List<Domain.Cost.Cost>? TheCostList { get; set; }

        public BuildingHistory? TheBuildingHistory { get; set; }

        public BuildingRegion? TheBuildingRegion { get; set; }

    }
}
