using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokensController : MonoBehaviour
{
    //TODO Get the player tokens from the API
    [Header("Tokens")]
    public int tokens;

    [Header("NFTs")]
    public int nftTokenCost = 3;
    [SerializeField]
    Image nftRewardImage;

    [Header("Components")]
    [SerializeField]
    Text tokensLabel;

    [SerializeField]
    SkinsController skinsController;

    private void Awake()
    {            
        tokensLabel.text = tokens.ToString();
        nftRewardImage.gameObject.SetActive(false);
    }

    //TODO Call the API to add the number of Tokens to the player account
    public void AddCoin(int amount)
    {
        tokens += amount;
        tokensLabel.text = tokens.ToString();
    }

    //TODO Call the API in order to collect a prize, the amount of tokens necessary should be subtracted and the prize revealed to be minted
    public void CollectPrize()
    {
        if (tokens - nftTokenCost >= 0)
        {
            tokens -= nftTokenCost;
            tokensLabel.text = tokens.ToString();
            ShowPrize();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    //TODO Show the player the NFT he needs to mint
    void ShowPrize()
    {
        nftRewardImage.gameObject.SetActive(true);
        //nftRewardImage.sprite = 
        //skinsController.GetRandomSkin();
        Invoke("HidePrize", 10);
    }

    void HidePrize()
    {
        nftRewardImage.gameObject.SetActive(false);
    }

    public void MintNFT()
    {
        //TODO Load the MINT session inside the platform, after the mint, the skin should be available to be used inside the game
        Application.OpenURL("http://unity3d.com/");
    }
}
