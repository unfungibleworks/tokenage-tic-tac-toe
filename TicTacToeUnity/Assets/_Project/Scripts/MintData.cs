using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    public class MintData
    {
        public string playerEmail;
        public string contract;
        public string id;
        public string name;
        public string description;
        public string image;
        public string category;


        public MintData(string _playerEmail, string _contract, string _id, string _name, string _description, string _image, string _category)                        
        {
            playerEmail = _playerEmail;
            contract = _contract;
            id = _id;
            name = _name;
            description = _description;
            image = _image;
            category = _category;
        }
    }
}