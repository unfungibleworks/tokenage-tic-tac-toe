using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tokenage
{
    //This class is used to store information from smart cotracts.
    [Serializable]
    public class UserNotMintedData
    {
        public string name;
        public string commission;
        public string provider;
        public Erc721ContractsData[] erc721Contracts;
        public Erc20ContractsData[] erc20Contracts;

        public UserNotMintedData(string _name, string _comission, string _provider, Erc721ContractsData[] _erc721Contracts, Erc20ContractsData[] _erc20Contracts)
        {
            name = _name;
            commission = _comission;
            provider = _provider;
            erc721Contracts = _erc721Contracts;
            erc20Contracts = _erc20Contracts;
        }
    }
}
