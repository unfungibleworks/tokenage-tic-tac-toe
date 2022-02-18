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

        //TODO API call to validade email
        //
        //
        Response tempResponse = new Response(true, "Login Success");
        if (tempResponse.LoginSuccess)
            LoadGame();
        else
            ShowErrorMessage(tempResponse.ErrorMessage);
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
    }

}
