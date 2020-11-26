using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chruchAi : MonoBehaviour
{
    GameObject GameHandler;
    
    void Start()
    {
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        InvokeRepeating("generatecurrency", 0, 10);
    }

    void generatecurrency(){
        if(GetComponent<getTowerInfo>().isActiveAndEnabled){
            addSeeds();
            addbrains();
        }
    }

    void addSeeds(){
        GameHandler.GetComponent<Economy>().addseeds(1);
    }

    void addbrains(){
        GameHandler.GetComponent<Economy>().addbrains(1);
    }
}
