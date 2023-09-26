using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoviePage : MonoBehaviour
{
    public Login script;
    [SerializeField] private TextMeshProUGUI alertLoginText;
    
    public void Awake()
    {

        alertLoginText.text = Login.loginScene.returnedAccount.username;
    }

}
