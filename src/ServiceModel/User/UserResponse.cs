namespace ServiceModel.User;

public class UserResponse
{
    public UserResponse()
    {
        this.theUserContractList = new List<UserContract>();
    }

    public List<UserContract> theUserContractList { get; set; }
}