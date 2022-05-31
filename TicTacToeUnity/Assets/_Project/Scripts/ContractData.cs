using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tokenage
{
    //This class is used to store information from contracts.
    [Serializable]
    public class ContractData
    {
        public string symbol;
        public string friendlyName;
        public string name;
        public string address;
        public TokenData[] nfts;

        public ContractData(string _symbol, string _friendlyName, string _name, string _address, TokenData[] _nfts)
        {
            symbol = _symbol;
            friendlyName = _friendlyName;
            name = _name;
            address = _address;
            nfts = _nfts;
        }
    }
}