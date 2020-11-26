using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Accepted by unity engine compiler. Visual studio give false errors.

public class brainsNumberText : MonoBehaviour
{
    //This is just for setting the text in gui.

    public Text text;

    public void settext(string textinput){
        text.text = textinput;
    }
}
