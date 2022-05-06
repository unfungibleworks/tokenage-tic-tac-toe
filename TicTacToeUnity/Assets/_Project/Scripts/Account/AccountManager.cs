using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager
{
    static AccountManager instance;
    private UserData userData;
    public string Name => userData!=null ? userData.name : "John Seller";
    public string Email => userData != null ? userData.email : "john.seller@mailinator.com";
    public string Wallet => userData != null ? userData.wallet : "";

    public static AccountManager GetInstance()
    {
        if (instance == null)
            instance = new AccountManager();
        return instance;
    }

    public void SetUser(string data)
    {
        userData = JsonUtility.FromJson<UserData>(data);
    }
}
