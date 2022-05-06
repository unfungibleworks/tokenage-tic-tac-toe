using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [SerializeField]
    InputField emailInputField;

    [SerializeField]
    InputField passwordInputField;

    [SerializeField]
    Button loginButton;

    [SerializeField]
    Button createAccountButton;

    [SerializeField]
    Text errorMessage;

    [SerializeField]
    Text errorMessageDetail;

    public string GameSceneName = "GameScene";



    struct Response
    {
        public bool LoginSuccess;
        public string ErrorMessage;

        public Response(bool _loginSuccess, string _errorMessage)
        {
            LoginSuccess = _loginSuccess;
            ErrorMessage = _errorMessage;
        }
    }


    private void Awake()
    {
        errorMessage.gameObject.SetActive(false);
    }

    //Connect to the API requesting entry into the game, needs a valid email account 
    public void Login()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        Tokenage.TokenageManager.GetInstance().UserDataRequest(email,password,(bool loginSuccess) =>
        {
            HandleResponse(loginSuccess);
        });
    }

    void HandleResponse(bool success)
    {
        if (success)
        {
            LoadGame();
        }
        else
            ShowErrorMessage("Login Failed");
    }

    public void CreateAccount()
    {
        //TODO Get the correct URL to create an Account inside the platform
        Application.OpenURL("http://unity3d.com/");
    }

    void LoadGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    void ShowErrorMessage(string message)
    {
        errorMessage.gameObject.SetActive(true);
        errorMessage.text = message;
        errorMessageDetail.text = "";
    }

}
