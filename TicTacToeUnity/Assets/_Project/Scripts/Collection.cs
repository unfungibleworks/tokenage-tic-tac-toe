using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    //This scriptable object store a collection contract and a list of collection items.
    [CreateAssetMenu(fileName = "Collection", menuName = "Tokenage/Collection", order = 1)]
    public class Collection : ScriptableObject
    {
        public string Contract;
        public List<CollectionItem> Items;

        public void InitializeCollection()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].SetContract(Contract);
            }
        }
    }
}
