using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grafMeny : MonoBehaviour
{
    // Settingsscripts in grafmeny

    public Dropdown resolutionDroppdown;

    Resolution[] deviceResolutions;

    public Toggle VsyncToggle;

    void Start()
    {
        deviceResolutions = Screen.resolutions;
        filldroppdownboxes();
        checkToggles();
    }

    void filldroppdownboxes(){
        resolutionfill();
    }

    void checkToggles(){
        if(QualitySettings.vSyncCount >= 1)
            VsyncToggle.isOn = true;
        else
            VsyncToggle.isOn = false;
    }
    
    void resolutionfill(){
        List<string> names = new List<string>();

        Resolution currentResolution = Screen.currentResolution;
        /* 
        Checking all the supported resoulutions
        * Removing anything lower will get the droppdown and resolutionsetter to be out of sync
        */
        int i = 0;
        int currentResOptionIndex = 0;
        foreach(var resolution in deviceResolutions){
            names.Add(resolution.ToString());

            if(currentResolution.height == resolution.height && currentResolution.width == resolution.width){
                currentResOptionIndex = i;
            }
            i++;
        }

        resolutionDroppdown.AddOptions(names);
        resolutionDroppdown.value = currentResOptionIndex;
    }

    public void windowmodetogle(){
        Screen.fullScreen = !Screen.fullScreen;

        if(Screen.fullScreen)
            Screen.SetResolution(Display.main.systemWidth / 2, Display.main.systemHeight / 2, false);
        else
            Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
    }

    public void setRes(int index){
        if(Screen.fullScreen)
            Screen.SetResolution(deviceResolutions[index].width, deviceResolutions[index].height, true);
        else
            Screen.SetResolution(deviceResolutions[index].width, deviceResolutions[index].height, false);
    }

    public void setVsync(){
        if(QualitySettings.vSyncCount == 1){
            QualitySettings.vSyncCount = 0;
            PlayerPrefs.SetString("Vsync", "False");
        }
        else{
            QualitySettings.vSyncCount = 1;
            PlayerPrefs.SetString("Vsync", "True");
        }

        PlayerPrefs.Save();
    }
}
