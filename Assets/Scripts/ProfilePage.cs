using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfilePage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alertFirstnameText;
    [SerializeField] private TextMeshProUGUI alertLastnameText;
    [SerializeField] private TextMeshProUGUI alertEmailText;
    [SerializeField] private TextMeshProUGUI alertUsernameText;

    [SerializeField] private TMP_InputField firstnameEditInputField;
    [SerializeField] private TMP_InputField lastnameEditInputField;
    [SerializeField] private TMP_InputField emailEditInputField;
    [SerializeField] private TMP_InputField usernameEditInputField;
    [SerializeField] private TMP_InputField passwordEditInputField;
    [SerializeField] private TMP_InputField confirmPasswordEditInputField;



    public void Update()
    {
        alertFirstnameText.text = "First Name: " + Login.currentAccount.firstname;
        alertLastnameText.text = "Last Name: " + Login.currentAccount.lastname;
        alertEmailText.text = "Email: " + Login.currentAccount.email;
        alertUsernameText.text = "Username: " + Login.currentAccount.username;
    }

    public void OnEditClick()
    {
        StartCoroutine(TryEdit());
    }

    private IEnumerator TryEdit()
    {
        string firstname = firstnameEditInputField.text;
        string lastname = lastnameEditInputField.text;
        string email = emailEditInputField.text;
        string username = usernameEditInputField.text;
        string password = passwordEditInputField.text;
        string confirmPassword = confirmPasswordEditInputField.text;


        yield return null;
    }


}