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

        [ForeignKey("BUILDINGID")]
        public virtual Building.Building? TheBuilding { get; set; }

        [ForeignKey("COSTTYPEID")]
        public virtual CostType? TheCostType { get; set; }

        [ForeignKey("OBJECTSTATEID")]
        public virtual Domain.ObjectState.ObjectState? TheObjectState { get; set; }

    }
}
