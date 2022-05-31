using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tokenage;

public class SkinsController : MonoBehaviour
{
    [Header("Tile Skins")]
    public Collection possibleTileSkins;
    private List<CollectionItem> storeTileSkins;
    private List<CollectionItem> ownedTileSkins;

    [Header("Board Skins")]
    public Collection possibleBoardSkins;
    private List<CollectionItem> storeBoardSkins;
    private List<CollectionItem> ownedBoardSkins;

    [Header("Prefabs")]
    [SerializeField]
    GameObject skinSelectPrefab;
    [SerializeField]
    GameObject skinBuyPrefab;
    [SerializeField]
    GameObject boardSkinSelectPrefab;
    [SerializeField]
    GameObject boardSkinBuyPrefab;

    [HideInInspector] 
    public CollectionItem CurrentTileSkin;

    [Header("Skins Containers")]
    [SerializeField]
    GameObject tileInventoryBox;
    [SerializeField]
    GameObject boardInventoryBox;
    [SerializeField]
    GameObject tileShopBox;
    [SerializeField]
    GameObject boardShopBox;

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
    GameObject inventory;
    [SerializeField]
    GameObject shop;
    [SerializeField]
    GameObject splash;

    private void Awake()
    {
        possibleBoardSkins.InitializeCollection();
        possibleTileSkins.InitializeCollection();

        storeBoardSkins = new List<CollectionItem>();
        for (int i = 0; i < possibleBoardSkins.Items.Count; i++)
        {
            storeBoardSkins.Add(possibleBoardSkins.Items[i]);
        }

        storeTileSkins = new List<CollectionItem>();
        for (int i = 0; i < possibleTileSkins.Items.Count; i++)
        {
            storeTileSkins.Add(possibleTileSkins.Items[i]);
        }

        ownedTileSkins = new List<CollectionItem>();
        ownedTileSkins.Add(possibleTileSkins.Items[0]);
        CurrentTileSkin = possibleTileSkins.Items[0];
        storeTileSkins.RemoveAt(0);

        ownedBoardSkins = new List<CollectionItem>();
        ownedBoardSkins.Add(possibleBoardSkins.Items[0]);
        storeBoardSkins.RemoveAt(0);

        inventory.SetActive(false);
        shop.SetActive(false);
        NFTManager.GetInstance().updateNFTs += UpdateInventoryFromOnlineRequest;
    }

    public void UpdateInventoryFromOnlineRequest()
    {
        List<Collection> collections = new List<Collection>();
        collections.Add(possibleBoardSkins);
        collections.Add(possibleTileSkins);

        List<List<CollectionItem>> collectionItems;
        collectionItems = NFTManager.GetInstance().ReturnOnlineCollectionItensByLocalCollections(collections);

        for (int i = 0; i < collectionItems[0].Count; i++)
        {
            storeBoardSkins.Remove(collectionItems[0][i]);
            ownedBoardSkins.Add(collectionItems[0][i]);
        }

        for (int i = 0; i < collectionItems[1].Count; i++)
        {
            storeTileSkins.Remove(collectionItems[1][i]);
            ownedTileSkins.Add(collectionItems[1][i]);
        }

        splash.SetActive(false);
    }

    public void ToggleSkinsInventory()
    {
        if (!inventory.activeInHierarchy)
        {
            if (shop.activeInHierarchy) shop.SetActive(false);
            inventory.SetActive(true);
            gameController.CanInteractWithGame = false;
            RefreshSkins(true);
        }
        else
        {
            inventory.SetActive(false);
            gameController.CanInteractWithGame = true;
        }
    }

    public void ToggleSkinsShop()
    {
        if (!shop.activeInHierarchy)
        {
            if (inventory.activeInHierarchy) inventory.SetActive(false);
            shop.SetActive(true);
            gameController.CanInteractWithGame = false;
            RefreshSkins(false);
        }
        else
        {
            shop.SetActive(false);
            gameController.CanInteractWithGame = true;
        }
    }

    private void RefreshSkins(bool isFromInventory)
    {
        if (isFromInventory)
        {
            if (ownedTileSkins.Count >= tileInventoryBox.transform.childCount)
                RefreshTileSkins(isFromInventory);

            if (ownedBoardSkins.Count >= boardInventoryBox.transform.childCount)
                RefreshBoardSkins(isFromInventory);
        }
        else
        {
            if (ownedTileSkins.Count >= tileShopBox.transform.childCount)
                RefreshTileSkins(isFromInventory);

            if (ownedBoardSkins.Count >= boardShopBox.transform.childCount)
                RefreshBoardSkins(isFromInventory);
        }
    }

    void RefreshTileSkins(bool isFromInventory)
    {
        GameObject newSkinSelect;
        if (isFromInventory)
        {
            for (int i = tileInventoryBox.transform.childCount; i < ownedTileSkins.Count; i++)
            {
                newSkinSelect = Instantiate(skinSelectPrefab, tileInventoryBox.transform);
                newSkinSelect.GetComponent<SkinSelect>().SetSkin(ownedTileSkins[i], this);
            }
        }
        else
        {
            for (int i = tileShopBox.transform.childCount; i < storeTileSkins.Count; i++)
            {
                newSkinSelect = Instantiate(skinBuyPrefab, tileShopBox.transform);
                newSkinSelect.GetComponent<SkinSelect>().SetSkin(storeTileSkins[i], this);
            }
        }
    }

    void RefreshBoardSkins(bool isFromInventory)
    {
        GameObject newBoardSkinSelect;
        if (isFromInventory)
        {
            for (int i = boardInventoryBox.transform.childCount; i < ownedBoardSkins.Count; i++)
            {
                newBoardSkinSelect = Instantiate(boardSkinSelectPrefab, boardInventoryBox.transform);
                newBoardSkinSelect.GetComponent<BoardSkinSelect>().SetBoardSkin(ownedBoardSkins[i], this);
            }
        }
        else
        {
            for (int i = boardShopBox.transform.childCount; i < storeBoardSkins.Count; i++)
            {
                newBoardSkinSelect = Instantiate(boardSkinBuyPrefab, boardShopBox.transform);
                newBoardSkinSelect.GetComponent<BoardSkinSelect>().SetBoardSkin(storeBoardSkins[i], this);
            }
        }
    }

    public bool BuyBoard(CollectionItem _boardSprite)
    {
        if (coinController.tokens >= coinController.nftTokenCost)
        {
            RewardsController.RescueNFT(_boardSprite);
            storeBoardSkins.Remove(_boardSprite);
            ownedBoardSkins.Add(_boardSprite);
            coinController.tokens -= coinController.nftTokenCost;
            return true;
        }
        return false;
    }

    public bool BuySkin(CollectionItem _skin)
    {
        if (coinController.tokens >= coinController.nftTokenCost)
        {
            RewardsController.RescueNFT(_skin);
            storeTileSkins.Remove(_skin);
            ownedTileSkins.Add(_skin);
            coinController.tokens -= coinController.nftTokenCost;
            return true;
        }
        return false;
    }

    private void OnDestroy()
    {
        NFTManager.GetInstance().updateNFTs -= UpdateInventoryFromOnlineRequest;
    }
}
