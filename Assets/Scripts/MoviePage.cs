using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class MoviePage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alertLoginText;

    [SerializeField] private TextMeshProUGUI alertLoadingText;

    [SerializeField] private TMP_InputField cardNumInputField;
    [SerializeField] private TMP_InputField expDateInputField;
    [SerializeField] private TMP_InputField cvvInputField;
    [SerializeField] private TMP_InputField cardholderFullnameField;
    [SerializeField] private TMP_InputField billingAddressField;


    public GameObject PurchaseSuccessPanel;

    public void Awake()
    {
        alertLoginText.text = "Hello, " + Login.returnedAccount.firstname;
    }

    public void OnSubmitClick()
    {
        alertLoadingText.text = "Loading payment...";
        StartCoroutine(TrySubmitPurchase());
    }

    private IEnumerator TrySubmitPurchase()
    {
        string cardnum = cardNumInputField.text;
        string expDate = expDateInputField.text;
        string cvv = cvvInputField.text;
        string fullname = cardholderFullnameField.text;
        string billingAddress = billingAddressField.text;

        if (Regex.IsMatch(cardnum, @"^[0-9]*$") == false || cardnum.Length != 16)
        {
            alertLoadingText.text = "Invalid card number";
            yield break;
        }

        if (Regex.IsMatch(expDate, @"^[0-9]*$") == false || expDate.Length <3 || expDate.Length > 8)
        {
            alertLoadingText.text = "Expiration Date";
            yield break;
        }

        if (Regex.IsMatch(cvv, @"^[0-9]*$") == false || cvv.Length < 3 || cvv.Length > 4 )
        {
            alertLoadingText.text = "Invalid CVV";
            yield break;
        }

        if (fullname.Length < 1)
        {
            alertLoadingText.text = "Please enter your full name";
            yield break;
        }

        if (billingAddress.Length < 1)
        {
            alertLoadingText.text = "Please enter your billing address";
            yield break;
        }


        //PurchaseSuccessPanel.SetActive(true);

        yield return null;
    }

}
