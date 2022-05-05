using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tokenage
{
    public class CollectionManager
    {
        static CollectionManager instance;

        List<Collection> Collections;

        public static CollectionManager GetInstance()
        {
            if (instance == null)
                instance = new CollectionManager();
            return instance;
        }

        void LoadCollections()
        {
            Collections = Resources.LoadAll<Collection>("Collections")?.ToList();
        }

        public Collection GetCollection(string contract)
        {
            if (Collections == null)
                LoadCollections();
            return Collections.FirstOrDefault(x => x.Contract == contract);
        }

        //Return the user available rewards from the contract
        public CollectionItem[] GetAvailableItems(string contract)
        {
            string email = AccountManager.GetInstance().Email;
            return null;
        }
    }
}