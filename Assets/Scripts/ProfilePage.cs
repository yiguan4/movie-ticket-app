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

    public void Update()
    {
        alertFirstnameText.text = "First Name: " + Login.returnedAccount.firstname;
        alertLastnameText.text = "Last Name: " + Login.returnedAccount.lastname;
        alertEmailText.text = "Email: " + Login.returnedAccount.email;
        alertUsernameText.text = "Username: " + Login.returnedAccount.username;
    }


}
