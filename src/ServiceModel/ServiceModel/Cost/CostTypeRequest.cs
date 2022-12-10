namespace ServiceModel.Cost;

public class CostTypeRequest
{
    public CostTypeRequest()
    {
        theCostTypeContract = new CostTypeContract();
    }

    public CostTypeContract theCostTypeContract { get; set; }
}