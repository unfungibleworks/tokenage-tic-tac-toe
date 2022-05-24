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
        public string image;
        public string id;
        public string category;
        public string attributes;
        public string tokenId;
        public string owner;
        public string ownerName;
        public string contract;
        public string contractName;
        public string contractFriendlyName;
        public string gameId;
        public string gameName;
        public string commission;
        public string providerId;
        public string providerName;
        public bool minted;

        public ContractData(string _symbol, string _friendlyName, string _name, string _address, TokenData[] _nfts, string _image,
            string _id, string _category, string _attributes, string _tokenId, string _owner, string _ownerName, string _contract,
            string _contractName, string _contractFriendlyName, string _gameId, string _gameName, string _commision, string _providerId,
            string _providerName, bool _minted)
        {
            symbol = _symbol;
            friendlyName = _friendlyName;
            name = _name;
            address = _address;
            nfts = _nfts;
            image = _image;
            id = _id;
            category = _category;
            attributes = _attributes;
            tokenId = _tokenId;
            owner = _owner;
            ownerName = _ownerName;
            contract = _contract;
            contractFriendlyName = _contractFriendlyName;
            gameId = _gameId;
            gameName = _gameName;
            commission = _commision;
            providerId = _providerId;
            providerName = _providerName;
            minted = _minted;
        }
    }
}