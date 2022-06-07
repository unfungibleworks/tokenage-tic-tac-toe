using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Tokenage
{
    //This class is used to send and get information from the API.
    public class TokenageManager : MonoBehaviour
    {
        static TokenageManager instance;

        public static TokenageManager GetInstance()
        {
            if (instance == null)
            {
                GameObject go = new GameObject("TokenageManager");
                instance = go.AddComponent<TokenageManager>();
            }
            return instance;
        }

        #region Get Requests
        public void UserNFTsRequest(Action<bool> callback)
        {
            StartCoroutine(GetUserNFTsRequest("https://api.tokenage.io/v1/users/" + AccountManager.GetInstance().Wallet + "/assets", callback,
                (string returnValue) =>
                {
                    if (returnValue != string.Empty) NFTManager.GetInstance().SetRewards(returnValue);
                }));
            StartCoroutine(GetUserNFTsRequest("https://api.tokenage.io/v1/users/" + AccountManager.GetInstance().Wallet + "/nfts", callback,
                (string returnValue) =>
                {
                    if (returnValue != string.Empty) NFTManager.GetInstance().SetNFT(returnValue);
                }));
        }

        IEnumerator GetUserNFTsRequest(string url, Action<bool> callback, Action<string> value)
        {
            var request = new UnityWebRequest(url, "Get");
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            Debug.Log("Result: " + request.result);
            Debug.Log("Status Code: " + request.responseCode);
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                callback(false);
                value(string.Empty);
            }
            else if (request.result == UnityWebRequest.Result.Success)
            {
                callback(true);
                value(request.downloadHandler.text);
            }
        }

        #endregion

        #region Post Requests
        public void MintRequest(string contract, string tokenId, string tokenName, string tokenDescription, string tokenImage, string tokenCategory)
        {
            MintData data = new MintData(
                    AccountManager.GetInstance().Email,
                    contract,
                    tokenId,
                    tokenName,
                    tokenDescription,
                    tokenImage,
                    tokenCategory);

            string bodyJsonString = JsonUtility.ToJson(data);

            StartCoroutine(PostRequest(bodyJsonString, "https://api.tokenage.io/v1/assets"));
        }

        public void CUTILRewardRequest(int amount)
        {
            ClientUtilityTokenData data = new ClientUtilityTokenData(
                AccountManager.GetInstance().Email,
                TokenageSettingsManager.Instance.tokenageGameSettings.ReturnERC20Contract(),
                amount.ToString());

            string bodyJsonString = JsonUtility.ToJson(data);

            StartCoroutine(PostRequest(bodyJsonString, "https://api.tokenage.io/v1/assets/tokens"));
        }

        IEnumerator PostRequest(string data, string url)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log("Result: " + request.result);
            Debug.Log("Status Code: " + request.responseCode);
        }

        public void UserDataRequest(string email, string password, Action<bool> callback)
        {
            LoginData data = new LoginData(email, password);

            string bodyJsonString = JsonUtility.ToJson(data);

            StartCoroutine(GetUserDataRequest(bodyJsonString, "https://api.tokenage.io/v1/users/login", callback));
        }

        IEnumerator GetUserDataRequest(string data, string url, Action<bool> callback)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log("Result: " + request.result);
            Debug.Log("Status Code: " + request.responseCode);
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                callback(false);
            else if (request.result == UnityWebRequest.Result.Success)
            {
                AccountManager.GetInstance().SetUser(request.downloadHandler.text);
                callback(true);
            }
        }
        #endregion
    }
}
