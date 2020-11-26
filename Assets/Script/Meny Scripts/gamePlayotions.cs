using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Accepted by unity engine compiler. Visual studio give false errors.

public class gamePlayotions : MonoBehaviour
{
    public Dropdown dificultyDropdown;
    public Dropdown mapDroppdown;

    void Start()
    {
        filldroppdownboxes();
    }

    void filldroppdownboxes(){
        dificultyfill();
        fillmaplist();
    }

    void dificultyfill(){
        // The list must be sorted from easiest to hardes
        List<string> deficultylevels = new List<string>();

        deficultylevels.Add("Easy");
        deficultylevels.Add("Avarage");
        deficultylevels.Add("Hard");

        dificultyDropdown.AddOptions(deficultylevels);
        
        // The game shoude have made savefile by this point but added this for safty
        try{
            dificultyDropdown.value = PlayerPrefs.GetInt("DificultyInt");
        }
        catch{
            Debug.Log("No settingsaved");
            PlayerPrefs.SetInt("DificultyInt", 2);
        }
    }

    Object[] allMaps;

    void fillmaplist(){
        allMaps = Resources.LoadAll("MappreFabs", typeof(GameObject));
        List<string> maps = new List<string>();

        foreach (var map in allMaps)
        {
            maps.Add(map.name);
        }

        mapDroppdown.AddOptions(maps);

        mapDroppdown.value = PlayerPrefs.GetInt("mapIndex");
    }

    public void setDifficluty(int index){
        Debug.Log("Dificulty changed");
        PlayerPrefs.SetInt("DificultyInt", index);

        // is calld uppon from an droppdown function
        // ID number of the dificulty is the primary way to change the dificulty
        // The game scen will set it the name to coresponding id number. In the gameplayparameters.
        // The dificulty string is for gui only.
        setstringtoiddificulty();
        savetofile();
    }

    public void setMap(int index){
        // Is calld uppon from an droppdown function
        // ID number of the map is used to set the specifics prefab map in the gamemeny.
        PlayerPrefs.SetInt("mapIndex", index);

        try{
            allMaps = Resources.LoadAll("MappreFabs", typeof(GameObject));
        }
        catch{
            Debug.Log("Error loading mapprefabs- settingsmeny.cs");
        }

        int i = 0;
        foreach (var map in allMaps)
        {
            if(i == index){
                PlayerPrefs.SetString("mapName", map.name);
                Debug.Log("mapname: " + map.name);
            }
            
            i++;
        }

        Debug.Log("Map changed");
        Debug.Log(PlayerPrefs.GetString("mapName"));

        savetofile();
    }

    void setstringtoiddificulty(){
        string Dificulty = " ";

        if (PlayerPrefs.GetInt("DificultyInt") == 0){
            Dificulty = "Easy";
        } else if (PlayerPrefs.GetInt("DificultyInt") == 1){
            Dificulty = "Avarage";
        } else if (PlayerPrefs.GetInt("DificultyInt") >= 2){
            Dificulty = "Hard";
        }

        PlayerPrefs.SetString("Dificulty", Dificulty);
    }

    void savetofile(){
        PlayerPrefs.Save();
    }
}
