using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [HideInInspector] public int MyIndex;
    [HideInInspector] public bool IsFilledX = false;
    [HideInInspector] public bool IsFilledY = false;

    [SerializeField]
    GameController controller;
    [SerializeField]
    SkinsController skinsController;

    Image thisImage;

    private void Awake()
    {
        thisImage = GetComponent<Image>();
    }

    public void Selected()
    {
        if (!IsFilledX && !IsFilledY && controller.CanInteractWithGame)
        {
            FillTile(true);
            controller.OnTileClick(MyIndex);
        }
    }

    public void FillTile(bool isX)
    {
        thisImage.color = Color.white;
        if (isX)
        {
            thisImage.sprite = skinsController.CurrentTileSkin.xSprite;
            IsFilledX = true;
        }
        else
        {
            thisImage.sprite = skinsController.CurrentTileSkin.oSprite;
            IsFilledY = true;
        }
    }

    public void ResetTile()
    {
        thisImage.color = new Color(255, 255, 255, 0);
        IsFilledY = false;
        IsFilledX = false;
    }
}
