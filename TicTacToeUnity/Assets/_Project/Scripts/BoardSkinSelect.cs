using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSkinSelect : MonoBehaviour
{
    Sprite boardSkin;
    SkinsController skinsController;
    [SerializeField]
    Image boardSkinIcon;

    public void SetBoardSkin(Sprite skinSprite, SkinsController controller)
    {
        boardSkin = skinSprite;
        boardSkinIcon.sprite = skinSprite;
        skinsController = controller;
    }

    public void ChangeSkin()
    {
        skinsController.BoardImage.sprite = boardSkin;
        skinsController.ToggleSkinsPanel();
    }
}
