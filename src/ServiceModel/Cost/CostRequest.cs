
namespace ServiceModel.Cost;

public class CostRequest
{
    public CostRequest()
    {
        this.theCostContract = new CostContract();
    }

    public CostContract theCostContract { get; set; }
}