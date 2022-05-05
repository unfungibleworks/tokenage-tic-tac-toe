using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    public class ClientUtilityTokenData
    {
        public string playerEmail;
        public string contract;
        public string value;

        public ClientUtilityTokenData(string _playerEmail, string _contract, string _value)
        {
            playerEmail = _playerEmail;
            contract = _contract;
            value = _value;
        }
    }
}
