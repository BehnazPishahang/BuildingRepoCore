namespace ServiceModel.User;

public class UserRequest
{
    public UserRequest()
    {
        theUserContract = new UserContract();
    }

    public UserContract theUserContract { get; set; }
}