using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    GameObject GameHandler;

    int currentvawelevel = 0;
    
    void Start()
    {
        load();
    }

    void load(){
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    public int getCurrentLevel()
    {
        return currentvawelevel;
    }

    public void setCurrentLevel(int _inputLevel)
    {
        currentvawelevel = _inputLevel;
        updatesavestate();
    }

    public void updatesavestate(){
        GameHandler.GetComponent<SaveGameScript>().setCurrentLevel(currentvawelevel);
    }

    int maxlevel = 1;
    void restartlevels()
    {
        setCurrentLevel(1);
    }

    public void setmaxlevel(int inputlevel)
    {
        maxlevel = inputlevel;
    }

    void levelsetter()
    {
        int currentlevel            = getCurrentLevel();
        currentlevel                = currentlevel + 1;

        setCurrentLevel(currentlevel);

        Debug.Log("Next level");

        if(currentlevel > maxlevel){
            restartlevels();
            Debug.Log("Max level reacht. Reset to lvl 1 with dificulty");
            PlayerPrefs.SetInt("HawWonGame", 1);
        }
    }
}
