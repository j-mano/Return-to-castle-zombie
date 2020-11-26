using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesInScene : MonoBehaviour
{
    // This document handle all the enemies in the sceen. paus/resume tower ai is building on this script.
    // to take care of enemies in each object by GameObject.FindGameObjectsWithTag("enemyTag") is cpu heavy.
    GameObject[] enemies;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemyTag");
    }

    void Update()
    {
        // Fixt update will giv problem with spawner. use this or rebuild so the list moust be updated for each instancing of an enemy
        findenemies();
    }

    public void findenemies(){
        enemies = GameObject.FindGameObjectsWithTag("enemyTag");
    }

    public void removeenemie(){
        List<GameObject> enmielist = new List<GameObject>();

        foreach(GameObject eneme in enemies){
            if(eneme != null){
                enmielist.Add(eneme);
            }
        }

        if(enmielist!=null)
            enemies = enmielist.ToArray();
    }

    public GameObject[] getenemiesarray(){
        return enemies;
    }
}
