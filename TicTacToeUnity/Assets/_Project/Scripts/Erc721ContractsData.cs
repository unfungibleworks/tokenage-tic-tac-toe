using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tokenage
{
    //This class store information from smart contracts.
    [Serializable]
    public class Erc721ContractsData
    {
        public string symbol;
        public string friendlyName;
        public string name;
        public string address;
        public TokenRewardData[] nft;

        public Erc721ContractsData(string _symbol, string _friendlyName, string _name,
            string _address, TokenRewardData[] _nft)
        {
            symbol = _symbol;
            friendlyName = _friendlyName;
            name = _name;
            address = _address;
            nft = _nft;
        }
    }
}
