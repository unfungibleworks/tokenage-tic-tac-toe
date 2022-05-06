using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    [CreateAssetMenu(fileName = "CollectionData", menuName = "Tokenage/CollectionData", order = 1)]
    public class Collection : ScriptableObject
    {
        public string Name;
        public string Contract;
        public List<CollectionItem> Items;
    }
}
