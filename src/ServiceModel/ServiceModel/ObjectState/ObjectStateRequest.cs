namespace ServiceModel.ObjectState;

public class ObjectStateRequest
{
    public ObjectStateRequest()
    {
        this.theObjectStateContract = new ObjectStateContract();
    }

    public ObjectStateContract theObjectStateContract { get; set; }
}