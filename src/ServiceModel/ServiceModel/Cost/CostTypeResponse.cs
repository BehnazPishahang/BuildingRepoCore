namespace ServiceModel.Cost;

public class CostTypeResponse
{
    public CostTypeResponse()
    {
        this.theCostTypeContractList = new List<CostTypeContract>();
    }

    public List<CostTypeContract> theCostTypeContractList { get; set; }
}