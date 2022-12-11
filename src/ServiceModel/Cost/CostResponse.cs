namespace ServiceModel.Cost;

public class CostResponse
{
    public CostResponse()
    {
        this.theCostContractList = new List<CostContract>();
    }

    public List<CostContract> theCostContractList { get; set; }
}