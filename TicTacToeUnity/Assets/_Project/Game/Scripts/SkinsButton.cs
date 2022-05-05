using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsButton : MonoBehaviour
{
    [SerializeField]
    Button skinButton;

    [SerializeField]
    SkinsController skinsPanel;

    public void TogglePanel()
    {        
        skinsPanel.ToggleSkinsPanel();
    }

}
