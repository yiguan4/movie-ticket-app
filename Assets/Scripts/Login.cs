using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] private string loginEndpoint = "http://127.0.0.1:1234/account/login";
    [SerializeField] private string createEndpoint = "http://127.0.0.1:1234/account/create";


    [SerializeField] private TextMeshProUGUI alertLoginText;
    [SerializeField] private TextMeshProUGUI alertRegisterText;
    // [SerializeField] private Button loginButton;
    // [SerializeField] private Button createButton;
    [SerializeField] private TMP_InputField usernameLoginInputField;
    [SerializeField] private TMP_InputField passwordLoginInputField;
    [SerializeField] private TMP_InputField usernameRegisterInputField;
    [SerializeField] private TMP_InputField passwordRegisterInputField;

    public void OnLoginClick()
    {
        alertLoginText.text = "Signing in...";
        //  loginButton.interactable = false;
        StartCoroutine(TryLogin());

    }

    public void OnCreateClick()
    {
        alertRegisterText.text = "Registering account...";
        //   createButton.interactable = false;
        StartCoroutine(TryCreate());
    }

    private IEnumerator TryLogin()
    {


        string username = usernameLoginInputField.text;
        string password = passwordLoginInputField.text;

        if (username.Length < 3 || username.Length > 24)
        {
            alertLoginText.text = "Invalid username";
            //      loginButton.interactable = true;
            yield break;
        }

        if (password.Length < 3 || password.Length > 24)
        {
            alertLoginText.text = "Invalid password";
            //     loginButton.interactable = true;
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("cUsername", username);
        form.AddField("cPassword", password);

        UnityWebRequest request = UnityWebRequest.Post(loginEndpoint, form);
        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.downloadHandler.text != "Invalid credentials")
            {
                //        loginButton.interactable = false;
                UserAccount returnedAccount = JsonUtility.FromJson<UserAccount>(request.downloadHandler.text);
                alertLoginText.text = $"{returnedAccount._id} Welcome" + returnedAccount.username;
            }
            else
            {
                alertLoginText.text = "Invalid credentials";
                //    loginButton.interactable = true;
            }


        }
        else
        {
            alertLoginText.text = "Error connecting to the server...";
            //   loginButton.interactable = true;
        }


        yield return null;
    }

    private IEnumerator TryCreate()
    {
        string username = usernameRegisterInputField.text;
        string password = passwordRegisterInputField.text;

        if (username.Length < 3 || username.Length > 24)
        {
            alertRegisterText.text = "Invalid username11111";
            //      loginButton.interactable = true;
            yield break;
        }

        if (password.Length < 3 || password.Length > 24)
        {
            alertRegisterText.text = "Invalid password";
            //     loginButton.interactable = true;
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("cUsername", username);
        form.AddField("cPassword", password);

        UnityWebRequest request = UnityWebRequest.Post(createEndpoint, form);
        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }

            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.downloadHandler.text != "Invalid credentials" && request.downloadHandler.text != "Username is already taken")
            {
                //        loginButton.interactable = false;
                UserAccount returnedAccount = JsonUtility.FromJson<UserAccount>(request.downloadHandler.text);
                alertRegisterText.text = "Account has been created";
            }
            else
            {
                alertRegisterText.text = "Invalid credentials";
                //    loginButton.interactable = true;
            }


        }
        else
        {
            alertRegisterText.text = "Error connecting to the server...";
            //   loginButton.interactable = true;
        }


        yield return null;
    }

}
