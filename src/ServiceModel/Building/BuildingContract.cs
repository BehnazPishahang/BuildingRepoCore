using ServiceModel.Cost;

namespace ServiceModel.Building;

public class Building
{
    public Guid Id { get; set; }
    
    public string? Title { get; set; }

    public string? Address { get; set; }

    public int? FloorCount { get; set; }

    public int? Plaque { get; set; }

    public string? CityName { get; set; }

    public virtual List<CostContract>? TheCostList { get; set; }

}