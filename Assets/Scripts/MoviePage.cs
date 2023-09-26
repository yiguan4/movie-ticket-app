using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoviePage : MonoBehaviour
{
    public Login script;
    [SerializeField] private TextMeshProUGUI alertLoginText;


    // Start is called before the first frame update
    void Start()
    {

        alertLoginText.text = $"{script.returnedAccount._id} Welcome" + script.returnedAccount.username;
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
