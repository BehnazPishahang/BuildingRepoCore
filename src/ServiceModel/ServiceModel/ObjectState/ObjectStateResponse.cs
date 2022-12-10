namespace ServiceModel.ObjectState;

public class ObjectStateResponse
{
    public ObjectStateResponse()
    {
        this.theObjectStateContractList = new List<ObjectStateContract>();
    }

    public List<ObjectStateContract> theObjectStateContractList { get; set; }
}