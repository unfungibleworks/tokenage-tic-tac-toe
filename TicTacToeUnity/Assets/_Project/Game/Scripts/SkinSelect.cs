using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tokenage;

public class SkinSelect : MonoBehaviour
{
    CollectionItem mySkin;

    [SerializeField]
    Image skinIcon;

    SkinsController skinsController;

    public void SetSkin(CollectionItem skin, SkinsController controller)
    {
        mySkin = skin;
        skinIcon.sprite = skin.Objects[0] as Sprite;
        skinsController = controller;
    }

    public void ChangeSkin()
    {
        skinsController.CurrentTileSkin = mySkin;
        skinsController.ToggleSkinsInventory();

        Tile[] allTiles = FindObjectsOfType<Tile>();
        for (int i = 0; i < allTiles.Length; i++)
        {
            if (allTiles[i].IsFilledX)            
                allTiles[i].GetComponent<Image>().sprite = mySkin.Objects[0] as Sprite;            
            else if (allTiles[i].IsFilledY)            
                allTiles[i].GetComponent<Image>().sprite = mySkin.Objects[1] as Sprite;            
        }
    }

    public void BuySkin()
    {
        if (skinsController.BuySkin(mySkin)) Destroy(gameObject);
    }
}
