using UnityEngine;

//This class is used to store data from the user.
public class AccountManager
{
    static AccountManager instance;
    private UserData userData;
    public string Name;
    public string Email;
    public string Wallet;

    public static AccountManager GetInstance()
    {
        if (instance == null)
            instance = new AccountManager();
        return instance;
    }

    public void SetUser(string data)
    {
        userData = JsonUtility.FromJson<UserData>(data);

        Name = userData.name;
        Email = userData.email;
        Wallet = userData.wallet;
    }
}
