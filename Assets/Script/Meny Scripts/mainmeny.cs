using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmeny : MonoBehaviour
{
    // main meny scrip settings
    void Start()
    {
        // check if setting has been set before. othevise set defult settings. setting like resolution dificulty and audio.
        if (checkpreferensesiscreated())
            savetofile();
        else
            setdefultvalues();
        
        setsetvsync();
    }

    void setsetvsync(){
        string vsyncsetting = PlayerPrefs.GetString("Vsync");
        
        if(vsyncsetting == "False"){
            QualitySettings.vSyncCount = 0;
        }
    }

    // is used as a trigger function for the Play button.
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // is used as a trigger function for the quit button.
    public void QuitGame ()
    {
        Debug.Log("Aplication is shuting down");
        Application.Quit();
    }

    bool checkpreferensesiscreated(){
        bool Exists = false;

        if(PlayerPrefs.HasKey("Exists")){
            Exists = true;
        }
        
        return Exists;
    }
    
    // Setting the defult values of settings if no settings is found. this functions exist in settingsmeny and main meny.
    void setdefultvalues(){
        PlayerPrefs.SetString("Exists", "True");
        PlayerPrefs.SetInt("DificultyInt", 1);
        PlayerPrefs.SetString("Dificulty", "Avarage");

        // Audio
        PlayerPrefs.SetFloat("masterAudio", 1);
        PlayerPrefs.SetFloat("musicAudio", 1);
        PlayerPrefs.SetFloat("sfxAudio", 1);
        
        PlayerPrefs.SetInt("audioonof", 1);

        // This is for setting the default map of the game.
        Object[] allMaps;
        allMaps = Resources.LoadAll("MappreFabs", typeof(GameObject));

        int i = 0;
        foreach (var map in allMaps)
        {
            if(map.name == "Grid"){
                PlayerPrefs.SetInt("mapIndex", i);
                PlayerPrefs.SetString("mapName", map.name);
                break;
            } i++;
        }

        // Mananly saving all settings in case of crash.
        savetofile();
    }

    // Saves the settings manaly.
    void savetofile(){
        PlayerPrefs.Save();
    }
}
