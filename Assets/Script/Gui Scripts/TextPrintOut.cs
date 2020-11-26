using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrintOut : MonoBehaviour
{
    public Text Brains, Seeds;

    public GameObject gamehandler;

    int brains = 0,seeds = 0;

    void Update()
    {
        geteconomy();
        printtext();
    }

    void geteconomy(){
        brains = gamehandler.GetComponent<Economy>().getbrains();
        seeds  = gamehandler.GetComponent<Economy>().getseeds();
    }

    void printtext(){
        Brains.text = "Amount of brains: " +brains.ToString();
        Seeds.text  = "Amount of seeds: " + seeds.ToString();
    }
}
