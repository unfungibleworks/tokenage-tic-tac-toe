using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tokenage;

public class BoardSkinSelect : MonoBehaviour
{
    CollectionItem boardSkin;
    SkinsController skinsController;
    [SerializeField]
    Image boardSkinIcon;

    public void SetBoardSkin(CollectionItem skinSprite, SkinsController controller)
    {
        boardSkin = skinSprite;
        boardSkinIcon.sprite = skinSprite.Objects[0] as Sprite;
        skinsController = controller;
    }

    public void ChangeSkin()
    {
        skinsController.BoardImage.sprite = boardSkin.Objects[0] as Sprite;
        skinsController.ToggleSkinsInventory();
    }

    public void BuySkin()
    {
        skinsController.BuyBoard(boardSkin);
        Destroy(gameObject);
    }
}
