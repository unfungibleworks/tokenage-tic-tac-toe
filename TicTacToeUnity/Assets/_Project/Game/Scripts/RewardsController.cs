using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Tokenage;


public class RewardsController : MonoBehaviour
{
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
        GetNFTs();
    }

    public void AddCoin(int amount)
    {
        //Update the UI
        tokens += amount;
        tokensLabel.text = tokens.ToString();
    }

    public static void RescueNFT(CollectionItem item)
    {
        Tokenage.TokenageManager.GetInstance().MintRequest(
            item.contract,
             item.Id,
             item.Name,
             item.Description,
             item.Image,
             item.Category
            );
    }

    public void GetNFTs()
    {
        TokenageManager.GetInstance().UserNFTsRequest((bool loginSuccess) =>
        {

        });
    }

    public void RescueCoins()
    {
        Tokenage.TokenageManager.GetInstance().CUTILRewardRequest(tokens);
        tokens = 0;
        tokensLabel.text = tokens.ToString();
    }

}
