using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    public class TokenData
    {
        public string name;
        public string description;
        public string image;
        public string id;
        public string category;
        public TokenAttributesData tokenAttributesData;
        public string tokenId;
        public string owner;
        public string ownerName;
        public string contract;
        public string contractName;
        public string contractFriendlyName;
        public string gameId;
        public string gameName;
        public string comission;
        public string providerId;
        public string providerName;
        public bool minted;

        public TokenData(string _name, string _description, string _image, string _id, string _category,
            TokenAttributesData _tokenAttributesData, string _tokenId, string _owner, string _ownerName, string _contract,
            string _contractName, string _contractFriendlyName, string _gameId, string _gameName, string _comission,
            string _providerId, string _providerName, bool _minted)
        {
            name = _name;
            description = _description;
            image = _image;
            id = _id;
            category = _category;
            tokenAttributesData = _tokenAttributesData;
            tokenId = _tokenId;
            owner = _owner;
            ownerName = _ownerName;
            contract = _contract;
            contractName = _contractName;
            contractFriendlyName = _contractFriendlyName;
            gameId = _gameId;
            gameName = _gameName;
            comission = _comission;
            providerId = _providerId;
            providerName = _providerName;
            minted = _minted;
        }
    }

    public class TokenAttributesData
    {
    }
}
