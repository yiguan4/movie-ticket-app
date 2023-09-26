using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    [SerializeField] private string loginEndpoint = "http://127.0.0.1:1234/account/login";
    [SerializeField] private string registerEndpoint = "http://127.0.0.1:1234/account/register";

    [SerializeField] private TextMeshProUGUI alertLoginText;
    [SerializeField] private TextMeshProUGUI alertRegisterText;
    [SerializeField] private TMP_InputField usernameLoginInputField;
    [SerializeField] private TMP_InputField passwordLoginInputField;

    [SerializeField] private TMP_InputField firstnameRegisterInputField;
    [SerializeField] private TMP_InputField lastnameRegisterInputField;
    [SerializeField] private TMP_InputField emailRegisterInputField;
    [SerializeField] private TMP_InputField usernameRegisterInputField;
    [SerializeField] private TMP_InputField passwordRegisterInputField;
    [SerializeField] private TMP_InputField confirmPasswordRegisterInputField;

    public UserAccount returnedAccount;

    public void OnLoginClick()
    {
        alertLoginText.text = "Signing in...";
        StartCoroutine(TryLogin());

        

    }

    public void OnRegisterClick()
    {
        alertRegisterText.text = "Registering account...";
        StartCoroutine(TryRegister());
    }

    private IEnumerator TryLogin()
    {
        string username = usernameLoginInputField.text;
        string password = passwordLoginInputField.text;

        if (username.Length < 3 || username.Length > 24)
        {
            alertLoginText.text = "Invalid username";
            yield break;
        }

        if (password.Length < 3 || password.Length > 24)
        {
            alertLoginText.text = "Invalid password";
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
                returnedAccount = JsonUtility.FromJson<UserAccount>(request.downloadHandler.text);
                alertLoginText.text = $"{returnedAccount._id} Welcome" + returnedAccount.username;
            }
            else
            {
                alertLoginText.text = "Invalid credentials";
            }

        }
        else
        {
            alertLoginText.text = "Error connecting to the server...";
        }


        yield return null;
    }


    private IEnumerator TryRegister()
    {
        string firstname = firstnameRegisterInputField.text;
        string lastname = lastnameRegisterInputField.text;
        string email = emailRegisterInputField.text;
        string username = usernameRegisterInputField.text;
        string password = passwordRegisterInputField.text;
        string confirmPassword = confirmPasswordRegisterInputField.text;

        if (Regex.IsMatch(firstname, @"^[a-zA-Z]+$") == false || firstname.Length < 3 || firstname.Length > 24) {
            alertRegisterText.text = "Invalid first name";
            yield break;
        }

        if (Regex.IsMatch(lastname, @"^[a-zA-Z]+$") == false || lastname.Length < 3 || lastname.Length > 24)
        {
            alertRegisterText.text = "Invalid last name";
            yield break;
        }

        if (Regex.IsMatch(email, @"^[^@\s] +@[^@\s]+\.(com | net | org | gov)$") ) {
            alertRegisterText.text = "Invalid email";
            yield break;
        }

        if (username.Length < 3 || username.Length > 24)
        {
            alertRegisterText.text = "Invalid username";
            yield break;
        }

        if (password.Length < 3 || password.Length > 24)
        {
            alertRegisterText.text = "Invalid password";
            yield break;
        }

        if (!String.Equals(password, confirmPassword))
        {
            alertRegisterText.text = "Password does not match";
            yield break;
        }


        WWWForm form = new WWWForm();
        form.AddField("first", firstname);
        form.AddField("last", lastname); 
        form.AddField("cEmail", email);
        form.AddField("cUsername", username);
        form.AddField("cPassword", password);

        UnityWebRequest request = UnityWebRequest.Post(registerEndpoint, form);
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
                returnedAccount = JsonUtility.FromJson<UserAccount>(request.downloadHandler.text);
                alertRegisterText.text = "Account has been created";
            }
            else
            {
                alertRegisterText.text = "Invalid credentials";
            }


        }
        else
        {
            alertRegisterText.text = "Error connecting to the server...";
        }


        yield return null;
    }

}
