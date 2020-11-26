using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionUpdate : MonoBehaviour
{
    public Text text;
    
    void Update()
    {
        text.text = "Current resolution: " + "\n" + "\n" + Screen.width + " X " + Screen.height;
    }
}
