using Domain.Building;
using Domain.Cost;
using Domain.ObjectState;

namespace ServiceModel.Cost;

public class CostContract
{
    public string Id { get; set; }
    
    public decimal? Amount { get; set; }

    public string? EventDate { get; set; }

    public string? FromDate { get; set; }

    public string? ToDate { get; set; }

    public decimal? CashAmount { get; set; }

    public Building? TheBuilding { get; set; }
    
    public CostType? TheCostType { get; set; }
    
    public ObjectState? TheObjectState { get; set; }
}