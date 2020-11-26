using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreation : MonoBehaviour
{
    // This script is loading the map prefab based on the settings in playerpreferenser files.
    // in practis is a playerprefab initated depending on the playerpref id and if no one exist is a defult map loaded.
    // a few extra functions exist to make sure no crases occure and so on.
    int mapId;
    bool findanything = false;

    public bool testmap = false;

    Object[] allMaps;

    void Start()
    {
        loadparameters();
        createmap();
    }

    void loadparameters(){
        try{ // Loading specifik map to create
            mapId   = PlayerPrefs.GetInt("mapIndex");
        }
        catch{
            Debug.Log("Faild to load what map to load - mapCreation.cs in gameobject: " + this.gameObject.name);
            InvokeRepeating("recheck", 1, 1f);
        }

        try{ // Loading all maps
            allMaps = Resources.LoadAll("MappreFabs", typeof(GameObject));
        }
        catch{
            Debug.Log("Error cant get map prefabs - mapCreation.cs in gameobject: " + this.gameObject.name);
            Debug.Log("Please check that mapprefabs exitsts in assets/resources/MappreFabs");
        }
    }

    void recheck(){
        try{
            mapId   = PlayerPrefs.GetInt("mapIndex");
            CancelInvoke("recheck");
            createmap();
        }
        catch{
            Debug.Log("Faild to load what map to load - mapCreation.cs in gameobject: " + this.gameObject.name);
        }
    }

    public void setdefultmap(){
        int i = 0;
        foreach (var map in allMaps)
        {
            if(map.name == "Grid"){
                PlayerPrefs.SetInt("mapIndex", i);
                PlayerPrefs.SetString("mapName", map.name);
                return;
            } i++;
        }
    }

    void createmap(){
        try{
            // check if mapprefabs is alredy loaded. this is to prevent dual load of tha same script or maploading from oter places.
            foreach(GameObject map in allMaps){
                if (GameObject.Find(map.name) != null)
                    findanything = true;
                else
                    findanything = false;
            }

            if(findanything == false){
                Instantiate(allMaps[mapId], new Vector2(0,0), transform.rotation);
                AstarPath.active.Scan();

                if(allMaps[mapId].name.Contains("Test")){
                    testmap = true;
                }
            }
            else
                Debug.Log("Error. Map is being loaded twice!!! - mapCreatorscript at at loaded in object: " + this.gameObject.name);
        }
        catch{
            Debug.Log("Error. Fail to check if map is loaded or not, or error while Instantiate the map itself. - mapCreatorscript at at loaded in object: " + this.gameObject.name);
        }
    }

    public bool getIsTestmap(){
        return testmap;
    }
}
