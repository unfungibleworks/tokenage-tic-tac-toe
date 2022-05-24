using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    //This scriptable object stores information to send a NFT request to the API.
    [CreateAssetMenu(fileName = "Collection Item", menuName = "Tokenage/Collection Item", order = 2)]
    public class CollectionItem : ScriptableObject
    {
        public string contract
        {
            get;
            private set;
        }
        [SerializeField]
        public string Id;
        [SerializeField]
        public string Name;
        [SerializeField]
        public string Description;
        [SerializeField]
        public string Image;
        [SerializeField]
        public string Category;
        [SerializeField]
        public UnityEngine.Object[] Objects;

        public void SetContract(string _contract)
        {
            contract = _contract;
        }
    }
}
