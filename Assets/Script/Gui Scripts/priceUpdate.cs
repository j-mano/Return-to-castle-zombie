using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceUpdate : MonoBehaviour
{
    //This documents purpose is to update the price of the meny towers

    public GameObject tower;

    public Text text;

    private string brainsTextInput, seedsTextInput;
    void Start()
    {
        settext();
    }

    void settext(){
        // This function is setting the text of the buttons in the touch controlls.
        // This is loaded on each button

        brainsTextInput = tower.GetComponent<getTowerInfo>().getTowercost().ToString();
        seedsTextInput  = tower.GetComponent<getTowerInfo>().getTowercostseeds().ToString();

        text.text = "Brains: " +  brainsTextInput + '\n' + "Seeds: " + seedsTextInput;
    }
}
