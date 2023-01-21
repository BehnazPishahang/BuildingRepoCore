using ServiceModel.Building;
using ServiceModel.ObjectState;

namespace ServiceModel.Cost;

public class CostContract
{
    public Guid Id { get; set; }
    
    public decimal? Amount { get; set; }

    public string? EventDate { get; set; }

    public string? FromDate { get; set; }

    public string? ToDate { get; set; }

    public decimal? CashAmount { get; set; }

    public Building.Building? TheBuilding { get; set; }
    
    public string? BuildingId { get; set; }
    
    public CostTypeContract? TheCostType { get; set; }
    
    public string? CostTypeId { get; set; }
    
    public ObjectStateContract? TheObjectState { get; set; }
    
    public string? ObjectStateId { get; set; }
}