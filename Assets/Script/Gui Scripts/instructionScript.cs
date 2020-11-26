using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionScript : MonoBehaviour
{
    public Text infoment, autohelth, increaseSpawn, decreseSpawn;

     private GameObject Gui;

    // Showing tex related to the testmap when a testmap is loaded
    void Start(){
        Gui         = GameObject.FindGameObjectWithTag("UI");
        SetControlltext();
        Invoke("Delaydload", 0.2f);
    }

    void Delaydload(){
        GameObject map = GameObject.FindGameObjectWithTag("Grid");

        if(map.name.Contains("Test")){
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
    }

    void SetControlltext(){
        infoment.text       = "Increase spawner ...... " + Gui.GetComponent<controllsManager>().getinfopanelMenytBtn().ToString();
        autohelth.text      = "Decrease spawner ....  " + Gui.GetComponent<controllsManager>().getautoHealthBtn().ToString();
        increaseSpawn.text  = "Autoadd Health .........  " + Gui.GetComponent<controllsManager>().getIncSpawnBtn().ToString();
        decreseSpawn.text   = "Stats and hardware ... " + Gui.GetComponent<controllsManager>().getDecSpawnBtn().ToString();
    }
}
