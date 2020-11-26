using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseMenyScript : MonoBehaviour
{
    /*
        This script is for the paus meny to take car of the gui of the pause meny

        Note to future devloper/devlopers of this program,
        It where plane to set audio here aswell but where not implemented due to time restriction of this version.
    */

    Resolution renderResolution;

    GameObject gamehandler, Gui;

    bool paused;

    public Toggle fullScreentoggle;

    public Text killdenemies, maplvl, pausetext;

    private int currentlevel;

    void Start()
    {
        load();
        statictextupdate();

        // Checking if pause meny is open at start. incase its open when started.
        checkIfgamepaused();

        if(paused == false)
            showpausemeny();
        else
            hidepausemeny();
    }

    void Update(){
        getLvl();
        killdenemies.text   = "Killed plants:" + " " + gamehandler.GetComponent<GameStatsManager >().getkilldZombies();
        maplvl.text         = "MapLvl:" + " " + currentlevel;
    }

    void statictextupdate(){
        pausetext.text      = "Pause meny. \nKey " + Gui.GetComponent<controllsManager>().getPauseBtn().ToString() + " to unpause";
    }

    void load(){
        renderResolution    = Screen.currentResolution;
        gamehandler         = GameObject.FindGameObjectWithTag("GameHandler");
        Gui                 = GameObject.FindGameObjectWithTag("UI");
    }

    void getLvl(){
        currentlevel = gamehandler.GetComponent<SaveGameScript>().getCurrentLevel();
    }

    void checkIfgamepaused(){
        paused = gamehandler.GetComponent<PauseManager>().getIfPaus();
    }

    void hidepausemeny(){
        this.gameObject.SetActive(false);
    }

    void showpausemeny(){
        this.gameObject.SetActive(true);
    }

    void checkToggles(){
        // Setting the toggle of fullscreen
        if(Screen.fullScreen == true)
            fullScreentoggle.isOn = true;
        else
            fullScreentoggle.isOn = false;
    }

    public void windowmodetogle(){
        Screen.fullScreen = !Screen.fullScreen;

        if(Screen.fullScreen)
            Screen.SetResolution(renderResolution.width / 2, renderResolution.height / 2, false);
        else
            Screen.SetResolution(renderResolution.width, renderResolution.height, true);
    }

    public void setMasterVolum(){

    }

    public void setSFXVolum(){

    }

    public void setMusicVolum(){

    }
}
