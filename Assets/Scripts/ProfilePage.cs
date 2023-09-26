using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfilePage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alertFirstnameText;

    public void Awake()
    {
        alertFirstnameText.text = "First Name: " + Login.returnedAccount.firstname;
    }


}
