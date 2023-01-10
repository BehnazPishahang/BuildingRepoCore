namespace ServiceModel.User;

public class UserAccessTypeResponse
{
    public UserAccessTypeResponse()
    {
        this.theUserAccessTypeContractList = new List<UserAccessTypeContract>();
    }

    public List<UserAccessTypeContract> theUserAccessTypeContractList { get; set; }
}