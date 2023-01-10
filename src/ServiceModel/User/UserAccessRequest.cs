namespace ServiceModel.User;

public class UserAccessRequest
{
    public UserAccessRequest()
    {
        theUserAccessContract = new UserAccessContract();
    }

    public UserAccessContract theUserAccessContract { get; set; }
}