using Domain.Cost;
using ServiceModel.Building;
using ServiceModel.ObjectState;

namespace ServiceModel.Cost;

public class CostContract
{
    public string Id { get; set; }
    
    public decimal? Amount { get; set; }

    public string? EventDate { get; set; }

    public string? FromDate { get; set; }

    public string? ToDate { get; set; }

    public decimal? CashAmount { get; set; }

    public BuildingContract? TheBuilding { get; set; }
    
    public CostTypeContract? TheCostType { get; set; }
    
    public ObjectStateContract? TheObjectState { get; set; }
}