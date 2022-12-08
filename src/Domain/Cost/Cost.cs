using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Cost
{
    public class Cost : BaseEntity
    {
        public decimal? Amount { get; set; }

        public string? EventDate { get; set; }

        public string? FromDate { get; set; }

        public string? ToDate { get; set; }

        public decimal? CashAmount { get; set; }

        public virtual Building.Building? TheBuilding { get; set; }
        
        public Guid BuildingId { get; set; }

        public virtual CostType? TheCostType { get; set; }

        public Guid CostTypeId { get; set; }
        
        public virtual Domain.ObjectState.ObjectState? TheObjectState { get; set; }
        
        public Guid ObjectStateId { get; set; }
    }
}
