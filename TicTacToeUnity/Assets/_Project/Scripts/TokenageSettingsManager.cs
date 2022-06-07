using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tokenage
{
    public class TokenageSettingsManager : MonoBehaviour
    {
        public TokenageGameSettings tokenageGameSettings;
        public static TokenageSettingsManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
