using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;

public class UIcontrolls : MonoBehaviour
{
    /*
        This document is handling the general controlls for the game itself.
        Shoude lay in the ui elements code and controlls.
    */

    public GameObject towerplacement, TowerSelectMeny, TowerSelectMeny2, pausemeny;

    private GameObject infopanel, GameHandler, Gui;

    public Text brainseconomy;

    int currentactivmeny = 0;

    void Start(){
        Load();
    }

    void Update(){
        specificButtonControll();
        ControllCheck();
    }

    void Load(){
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        Gui         = GameObject.FindGameObjectWithTag("UI");
        infopanel   = GameObject.FindGameObjectWithTag("devinfopanel");
        
        infopanel.SetActive(false);
    }

    // Checks specifik buttons like pause and esc and so on.
    void specificButtonControll()
    {
        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getinfopanelMenytBtn()))
        {
            if(infopanel.activeSelf)
                infopanel.SetActive(false);
            else
                infopanel.SetActive(true);
        }

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getMainMenytBtn()))
            openMainMeny();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getPauseBtn()) || Input.GetKeyDown(Gui.GetComponent<controllsManager>().getPauseBtn2())){
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.End))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.PageUp) || Input.GetKeyDown(KeyCode.PageDown))
            changeMeny();
    }

    void Pause(){
        if(pausemeny.activeSelf){
            pausemeny.SetActive(false);
            towerplacement.GetComponent<PauseManager>().resumePaus();
        }
        else{
            pausemeny.SetActive(true);
            towerplacement.GetComponent<PauseManager>().resumePaus();
        }
    }

    void ControllCheck()
    {
        // Todo: Link gui with hot key of towers.
        if(currentactivmeny > 1){
            alphaNumKeys2();
        }
        else{
            alphaNumKeys();
        }

        functionsKeys();
        keypadKeys();
        arrowKeys();
    }

    void hideMeny(){
        // Closing the gui meny
        TowerSelectMeny2.SetActive(false);
        TowerSelectMeny.SetActive(false);
    }

    int currentMeny(){
        currentactivmeny = 0;

        if(TowerSelectMeny.activeSelf){
            currentactivmeny = 1;
        }

        if(TowerSelectMeny2.activeSelf){
            currentactivmeny    = 2;
        }

        return currentactivmeny;
    }

    void changeMeny(){
        // Changing the gui to feature next tower selection meny
            if(currentMeny() == 0){
                TowerSelectMeny.SetActive(true);
            }

            if(currentMeny() == 1){
                TowerSelectMeny.SetActive(false);
                TowerSelectMeny2.SetActive(true);
            }

            if(currentMeny() == 2){
                TowerSelectMeny2.SetActive(false);
                TowerSelectMeny.SetActive(true);
            }

            if(currentMeny() > 2){
                TowerSelectMeny2.SetActive(false);
                TowerSelectMeny.SetActive(false);
            }
    }

    // controll of the f / function keys.
    void functionsKeys(){
        if (Input.GetKeyDown(KeyCode.F1))
            hideMeny();

        if (Input.GetKeyDown(KeyCode.F2))
            changeMeny();

        if (Input.GetKeyDown(KeyCode.F3)){

        }

        if (Input.GetKeyDown(KeyCode.F4)){

        }

        if (Input.GetKeyDown(KeyCode.F5)){
            
        }

        if (Input.GetKeyDown(KeyCode.F6)){

        }

        if (Input.GetKeyDown(KeyCode.F7)){

        }

        if (Input.GetKeyDown(KeyCode.F8)){

        }

        if (Input.GetKeyDown(KeyCode.F9)){
            
        }

        if (Input.GetKeyDown(KeyCode.F10)){

        }

        if (Input.GetKeyDown(KeyCode.F11)){

        }

        if (Input.GetKeyDown(KeyCode.F12)){

        }
    }

    void alphaNumKeys(){
        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn0()))
            towerplacement.GetComponent<towerPlcement>().selectedTower6();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn1()))
            towerplacement.GetComponent<towerPlcement>().selectedTower0();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn2()))
            towerplacement.GetComponent<towerPlcement>().selectedTower1();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn3()))
            towerplacement.GetComponent<towerPlcement>().selectedTower2();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn4()))
            towerplacement.GetComponent<towerPlcement>().selectedTower3();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn5()))
            towerplacement.GetComponent<towerPlcement>().selectedtsla();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn6()))
            towerplacement.GetComponent<towerPlcement>().selectedTower5();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn7()))
            towerplacement.GetComponent<towerPlcement>().selectedWall();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn8()))
            towerplacement.GetComponent<towerPlcement>().selectedMedecinhut();

        if (Input.GetKeyDown(Gui.GetComponent<controllsManager>().getHotKeyBtn9()))
            towerplacement.GetComponent<towerPlcement>().selectedChruch();

        /*if (Input.GetKeyDown(KeyCode.O))
            towerplacement.GetComponent<towerPlcement>().targettowernone();*/

        if (Input.GetKeyDown(KeyCode.Plus))
            towerplacement.GetComponent<towerPlcement>().targettowernone();

        if (Input.GetKeyDown(KeyCode.Quote))
            towerplacement.GetComponent<towerPlcement>().targettowernone();
    }

    // This is for future use and expansion for moore towers
    void alphaNumKeys2(){
        if (Input.GetKey(KeyCode.Alpha0)){
            
        }

        if (Input.GetKey(KeyCode.Alpha1)){
            
        }

        if (Input.GetKey(KeyCode.Alpha2)){
            
        }

        if (Input.GetKey(KeyCode.Alpha3)){
            
        }

        if (Input.GetKey(KeyCode.Alpha4)){
            
        }

        if (Input.GetKey(KeyCode.Alpha5)){
            
        }

        if (Input.GetKey(KeyCode.Alpha6)){
            
        }

        if (Input.GetKey(KeyCode.Alpha7)){
            
        }

        if (Input.GetKey(KeyCode.Alpha8)){
            
        }

        if (Input.GetKey(KeyCode.Alpha9)){
            
        }

        if (Input.GetKey(KeyCode.O)){
            towerplacement.GetComponent<towerPlcement>().targettowernone();
        }
    }

    // When numlock i aktiv
    void keypadKeys(){
        if (Input.GetKey(KeyCode.Keypad0))
            towerplacement.GetComponent<towerPlcement>().selectedTower6();

        if (Input.GetKey(KeyCode.Keypad1))
            towerplacement.GetComponent<towerPlcement>().selectedTower0();

        if (Input.GetKey(KeyCode.Keypad2))
            towerplacement.GetComponent<towerPlcement>().selectedTower1();

        if (Input.GetKey(KeyCode.Keypad3))
            towerplacement.GetComponent<towerPlcement>().selectedTower2();

        if (Input.GetKey(KeyCode.Keypad4))
            towerplacement.GetComponent<towerPlcement>().selectedTower3();

        if (Input.GetKey(KeyCode.Keypad5))
            towerplacement.GetComponent<towerPlcement>().selectedtsla();

        if (Input.GetKey(KeyCode.Keypad6))
            towerplacement.GetComponent<towerPlcement>().selectedTower5();

        if (Input.GetKey(KeyCode.Keypad7))
            towerplacement.GetComponent<towerPlcement>().selectedWall();

        if (Input.GetKey(KeyCode.Keypad8))
            towerplacement.GetComponent<towerPlcement>().selectedMedecinhut();

        if (Input.GetKey(KeyCode.Keypad9))
            towerplacement.GetComponent<towerPlcement>().selectedChruch();

        if (Input.GetKey(KeyCode.KeypadPlus))
            towerplacement.GetComponent<towerPlcement>().targettowernone();

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            towerplacement.GetComponent<towerPlcement>().controllfunction("place");
    }

    // When numlock i inaktiv
    void arrowKeys()
    {
        if (Input.GetKey(KeyCode.DownArrow))
            towerplacement.GetComponent<towerPlcement>().controllfunction("down");

        if (Input.GetKey(KeyCode.LeftArrow))
            towerplacement.GetComponent<towerPlcement>().controllfunction("left");

        if (Input.GetKey(KeyCode.Return))
            towerplacement.GetComponent<towerPlcement>().controllfunction("place");

        if (Input.GetKey(KeyCode.RightArrow))
            towerplacement.GetComponent<towerPlcement>().controllfunction("right");

        if (Input.GetKey(KeyCode.UpArrow))
            towerplacement.GetComponent<towerPlcement>().controllfunction("up");
    }

    public void openMainMeny(){
        brainseconomy.text = ("Saving");
        Debug.Log("saving");

        GameHandler.GetComponent<SaveGameScript>().savestate();
        
        Thread.Sleep(3000);
        Caching.ClearCache();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}