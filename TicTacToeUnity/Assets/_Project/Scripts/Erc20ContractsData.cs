using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tokenage
{
    //This class is used to store information from smart contracts.
    [Serializable]
    public class Erc20ContractsData
    {
        public string symbol;
        public string friendlyName;
        public string name;
        public string address;
        public Erc20Token[] token;

        public Erc20ContractsData(string _symbol, string _friendlyName, string _name, string _address, Erc20Token[] _token)
        {
            symbol = _symbol;
            friendlyName = _friendlyName;
            name = _name;
            address = _address;
            token = _token;
        }
    }

    public class Erc20Token
    {
        public string contractId;
        public string userId;
        public string value;
        public string sequence;
        public bool canClaim;
        public string pendingValue;
        public string pendingSequence;

        public Erc20Token(string _contractId, string _userId, string _value, string _sequence,
            bool _canClaim, string _pendingValue, string _pendingSequence)
        {
            contractId = _contractId;
            userId = _userId;
            value = _value;
            sequence = _sequence;
            canClaim = _canClaim;
            pendingValue = _pendingValue;
            pendingSequence = _pendingSequence;
        }
    }
}
