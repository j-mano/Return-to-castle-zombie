using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hutAI : MonoBehaviour
{
    GameObject castle;

    private int hutaddedhealht = 20;

    void Start()
    {
        InvokeRepeating("aiUpdate", 2, 0.5f);
    }

    void aiUpdate(){
       if(GetComponent<getTowerInfo>().isActiveAndEnabled) {
           addhealht();
           CancelInvoke();
       }
    }

    public void addhealht(){
        castle = GameObject.FindGameObjectWithTag("castle");
        castle.GetComponent<CastleManager>().addhealt(hutaddedhealht);
    }
}
