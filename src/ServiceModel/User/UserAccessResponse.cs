namespace ServiceModel.User;

public class UserAccessResponse
{
    public UserAccessResponse()
    {
        this.theUserAccessContractList = new List<UserAccessContract>();
    }

    public List<UserAccessContract> theUserAccessContractList { get; set; }
}