using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTestGameScript : MonoBehaviour
{
    // This scripts only purpose is to set upp the map from the torialmeny. thisd is to make it posseble for smowon new to get into the game.
    public void Starttestgame(){
        setmap();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void setmap(){
        Object[] allMaps;
        allMaps = Resources.LoadAll("MappreFabs", typeof(GameObject));

        int i = 0;
        foreach (var map in allMaps)
        {
            if(map.name == "Testmap"){
                PlayerPrefs.SetInt("mapIndex", i);
                PlayerPrefs.SetString("mapName", map.name);
                break;
            } i++;
        }
    }
}
