namespace ServiceModel.User;

public class UserAccessTypeRequest
{
    public UserAccessTypeRequest()
    {
        theUserAccessTypeContract = new UserAccessTypeContract();
    }

    public UserAccessTypeContract theUserAccessTypeContract { get; set; }
}