using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    //This class is used to store login information from the user.
    public class LoginData
    {
        public string email;
        public string password;

        public LoginData(string _email, string _password)
        {
            email = _email;
            password = _password;
        }
    }
}
