using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelect : MonoBehaviour
{
    Skin mySkin;

    [SerializeField]
    Image skinIcon;

    SkinsController skinsController;

    public void SetSkin(Skin skin, SkinsController controller)
    {
        mySkin = skin;
        skinIcon.sprite = skin.xSprite;
        skinsController = controller;
    }

    public void ChangeSkin()
    {
        skinsController.CurrentTileSkin = mySkin;
        skinsController.ToggleSkinsPanel();

        Tile[] allTiles = FindObjectsOfType<Tile>();
        for (int i = 0; i < allTiles.Length; i++)
        {
            if (allTiles[i].IsFilledX)            
                allTiles[i].GetComponent<Image>().sprite = mySkin.xSprite;            
            else if (allTiles[i].IsFilledY)            
                allTiles[i].GetComponent<Image>().sprite = mySkin.oSprite;            
        }
    }
}
