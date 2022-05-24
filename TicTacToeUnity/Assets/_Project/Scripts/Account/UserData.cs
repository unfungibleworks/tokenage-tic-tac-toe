public class UserData
{
    //This class is used to store data from the user.
    public string id;
    public string wallet;
    public string name;
    public string email;
    public string password;
    public string picture;
    public string webProvider;
    public string webProviderId;

    public UserData(string _id, string _wallet, string _name, string _email, string _password, string _picture, string _webProvider, string _webProviderId)
    {
        id = _id;
        wallet = _wallet;
        name = _name;
        email = _email;
        password = _password;
        picture = _picture;
        webProvider = _webProvider;
        webProviderId = _webProviderId;
    }
}
