using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsController : MonoBehaviour
{
    [Header("Tile Skins")]
    public List<Skin> possibleTileSkins;
    //TODO the API should return to the game the owned skins of the player
    private List<Skin> ownedTileSkins;

    [Header("Board Skins")]
    public List<Sprite> possibleBoardSkins;
    //TODO the API should return to the game the owned board skins of the player
    private List<Sprite> ownedBoardSkins;

    [Header("Prefabs")]
    [SerializeField]
    GameObject skinSelectPrefab;
    [SerializeField]
    GameObject boardSkinSelectPrefab;

    [HideInInspector] 
    public Skin CurrentTileSkin;

    [Header("Skins Containers")]
    [SerializeField]
    GameObject tileSkinsBox;
    [SerializeField]
    GameObject boardSkinsBox;

    [Header("Controllers")]
    [SerializeField]
    GameController gameController;
    [SerializeField]
    RewardsController coinController;

    [Header("Board")]
    [SerializeField]
    public Image BoardImage;

    [Header("Panel")]
    [SerializeField]
    GameObject panel;

    private void Awake()
    {        
        ownedTileSkins = new List<Skin>();
        ownedTileSkins.Add(possibleTileSkins[0]);
        CurrentTileSkin = possibleTileSkins[0];
        possibleTileSkins.RemoveAt(0);

        ownedBoardSkins = new List<Sprite>();
        ownedBoardSkins.Add(possibleBoardSkins[0]);
        possibleBoardSkins.RemoveAt(0);

        panel.SetActive(false);
    }

    public void ToggleSkinsPanel()
    {
        if (!panel.activeInHierarchy)
        {
            panel.SetActive(true);
            gameController.CanInteractWithGame = false;
            RefreshSkins();
        }
        else
        {
            panel.SetActive(false);
            gameController.CanInteractWithGame = true;
        }
    }

    //public void GetRandomSkin()
    //{
    //    if (possibleTileSkins.Count > 0 || possibleBoardSkins.Count > 0)
    //    {
    //        int sortingNumber = Random.Range(0, possibleTileSkins.Count + possibleBoardSkins.Count);

    //        if (sortingNumber < possibleTileSkins.Count)
    //        {
    //            ownedTileSkins.Add(possibleTileSkins[sortingNumber]);
    //            possibleTileSkins.RemoveAt(sortingNumber);
    //        }
    //        else if (sortingNumber >= possibleTileSkins.Count)
    //        {
    //            ownedBoardSkins.Add(possibleBoardSkins[sortingNumber - possibleTileSkins.Count]);
    //            possibleBoardSkins.RemoveAt(sortingNumber - possibleTileSkins.Count);
    //        }

    //        coinController.chestTextFeedback.color = Color.green;
    //        coinController.chestTextFeedback.text = "You got a new skin!";
    //        coinController.StartCoroutine(coinController.RunChestText());            
    //    }
    //    else
    //    {
    //        coinController.AddCoin(coinController.chestPrice);
    //        coinController.chestTextFeedback.color = Color.red;
    //        coinController.chestTextFeedback.text = "You already have all the skins!";
    //        coinController.StartCoroutine(coinController.RunChestText());
    //        Debug.Log("You already have all the skins!");
    //    }
    //}


    //TODO Get the owned skins from the API
    private void RefreshSkins()
    {
        if (ownedTileSkins.Count >= tileSkinsBox.transform.childCount)        
            RefreshTileSkins();

        if (ownedBoardSkins.Count >= boardSkinsBox.transform.childCount)
            RefreshBoardSkins();
    }

    void RefreshTileSkins()
    {
        GameObject newSkinSelect;
        for (int i = tileSkinsBox.transform.childCount; i < ownedTileSkins.Count; i++)
        {
            newSkinSelect = Instantiate(skinSelectPrefab, tileSkinsBox.transform);
            newSkinSelect.GetComponent<SkinSelect>().SetSkin(ownedTileSkins[i], this);
        }
    }

    void RefreshBoardSkins()
    {
        GameObject newBoardSkinSelect;
        for (int i = boardSkinsBox.transform.childCount; i < ownedBoardSkins.Count; i++)
        {
            newBoardSkinSelect = Instantiate(boardSkinSelectPrefab, boardSkinsBox.transform);
            newBoardSkinSelect.GetComponent<BoardSkinSelect>().SetBoardSkin(ownedBoardSkins[i], this);
        }
    }
}

[System.Serializable]
public class Skin
{
    public Sprite xSprite;
    public Sprite oSprite;
}
