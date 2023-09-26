using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoviePage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alertLoginText;
    
    public void Awake()
    {
        alertLoginText.text = "Hello, " + Login.returnedAccount.firstname;
    }
}
