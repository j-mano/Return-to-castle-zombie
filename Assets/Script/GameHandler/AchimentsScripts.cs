using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchimentsScripts : MonoBehaviour
{
    // This document is taking care of all achiments of the game and save them to playerpreferenses settings.
    Object[] allPrefabTower, allLoadedTower;

    GameObject GameHandler;

    bool[] tempboolarray;

    // The win game achiment is set in lvlsetter, the killachiments is set by each maps spawner for now.
    void Start()
    {
        Load();
        InvokeRepeating("hasplacedalltowers", 1, 2);
    }

    void Load(){
        GameHandler     = GameObject.FindGameObjectWithTag("GameHandler");
        allPrefabTower  = Resources.LoadAll("Prefab/Buildings/Tower", typeof(GameObject));
    }

    // This funktion is checking all tower loaded compared to all tower prefab existing in prefabfolder
    void hasplacedalltowers(){
        allLoadedTower = GameHandler.GetComponent<towersInScen>().getetowesarray();

        tempboolarray = new bool[allPrefabTower.Length];
        bool alltowersexit   = true;
        
        for(int i = 0; i < tempboolarray.Length; i++){
            tempboolarray[i] = false;
        }

        int i2 = 0;
        foreach (var Tower in allLoadedTower)
        {
            foreach (var Tower2 in allPrefabTower)
            {
                if(Tower.name == Tower2.name)
                    tempboolarray[i2] = true;
            }
        }

        foreach (var Tower2 in allPrefabTower)
        {
            if(tempboolarray[i2] != false)
                alltowersexit = false;
        }

        if(alltowersexit == true){
            setHasplacedalltowers();
        }
    }

    void setHasplacedalltowers(){
        PlayerPrefs.SetInt("Hasplacedalltowers", 1);
    }

    public void setkillmechaachiemnt(){
        PlayerPrefs.SetInt("HasKilledMechagnome", 1);
    }

    public void setwingameachiment(){
        PlayerPrefs.SetInt("HawWonGame", 1);
    }
}
