using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tokenage
{
    //This class is used to store data from the user.
    [Serializable]
    public class UserNFTGameData
    {
        public string name;
        public string commission;
        public string provider;
        public ContractData[] contracts;

        public UserNFTGameData(string _name, string _comission, string _provider, ContractData[] _contracts)
        {
            name = _name;
            commission = _comission;
            provider = _provider;
            contracts = _contracts;
        }
    }
}
