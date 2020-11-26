using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabTowersManager : MonoBehaviour
{
    // This script is preload all towerprefab from disk into ram. this handle all kind of towers in the game and reduce unnececary reads from disk.

    GameObject tower0, tower1, tower2, tower3, tower4, tower5, tower6, hut, chruch, Wall, zombie_on_lily;

    Object[] towers;

    // Start is called before the first frame update
    void Start()
    {
        // Here is all towerprefabs/gameobejcts loaded.
        tower0          = Resources.Load ("Prefab/Buildings/Tower/BallonHowerTowe")  as GameObject;
        tower1          = Resources.Load ("Prefab/Buildings/Tower/Watchtower")       as GameObject;
        tower2          = Resources.Load ("Prefab/Buildings/Tower/CanonTower")       as GameObject;
        tower3          = Resources.Load ("Prefab/Buildings/Tower/Tower_Zombie")     as GameObject;
        tower4          = Resources.Load ("Prefab/Buildings/Tower/Tesl_Coil")        as GameObject;
        tower5          = Resources.Load ("Prefab/Buildings/Tower/Trench")           as GameObject;
        tower6          = Resources.Load ("Prefab/Buildings/Tower/Treadmil")         as GameObject;
        hut             = Resources.Load ("Prefab/Buildings/Tower/Zombie_Hut")       as GameObject;
        Wall            = Resources.Load ("Prefab/Buildings/Tower/Blocktower")       as GameObject;
        chruch          = Resources.Load ("Prefab/Buildings/Tower/church")           as GameObject;
        zombie_on_lily  = Resources.Load ("Prefab/Buildings/Tower/zombie_on_lily")   as GameObject;

        towers          = Resources.LoadAll("Prefab/Buildings/Tower", typeof(GameObject));
    }

    // Get all towers
    public Object[] alltoweArray(){
        return towers;
    }

    // Below is individual towers
    public GameObject getBallonTower(){
        return tower0;
    }

    public GameObject getWatchTower(){
        return tower1;
    }

    public GameObject getCanonTower(){
        return tower2;
    }

    public GameObject getTower_Zombie(){
        return tower3;
    }

    public GameObject getTesla_Coil(){
        return tower4;
    }

    public GameObject getTrench(){
        return tower5;
    }

    public GameObject getTreadmil(){
        return tower6;
    }

    public GameObject getZombie_Hut(){
        return hut;
    }

    public GameObject getBlocktower(){
        return Wall;
    }

    public GameObject getChurch(){
        return chruch;
    }

    public GameObject getZombie_on_lily(){
        return zombie_on_lily;
    }
}
