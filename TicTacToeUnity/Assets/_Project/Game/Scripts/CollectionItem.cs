using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    [Serializable]
    public class CollectionItem
    {
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
        public Sprite Sprite;
    }
}
