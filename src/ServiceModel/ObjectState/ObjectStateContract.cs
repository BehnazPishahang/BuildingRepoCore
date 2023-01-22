namespace ServiceModel.ObjectState;

public class ObjectStateContract
{
    public Guid Id { get; set; }
    
    public string Code { get; set; }

    public string? Title { get; set; }
}