using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Tokenage;


public class RewardsController : MonoBehaviour
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
        //Update the UI
        tokens += amount;
        tokensLabel.text = tokens.ToString();

        Tokenage.TokenageManager.GetInstance().CUTILRewardRequest("",amount);
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

    public void RescueNFT()
    {
        //TODO Get Mint Data
        //Tokenage.TokenageManager.GetInstance().MintRequest();
    }

    public void GetNFTs()
    {
        TokenageManager.GetInstance().UserNFTsRequest(AccountManager.GetInstance().Wallet, (bool loginSuccess) =>
        {
            Debug.Log("");
        });
    }

}
