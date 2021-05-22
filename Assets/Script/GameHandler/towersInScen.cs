using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class towersInScen : MonoBehaviour
{
    // This code object is handling the towers instances in the scene. this is practaly creating an array of all towers in the game and sending it out.    GameObject[] towers;

    int towemax; // supposed to be max 100

    GameObject[] towers;

    async Task Start()
    {
        await findTowers();
        InvokeRepeating("SlowUpdate", 0, 0.3f);
    }

    public async Task findTowers(){
        towers = GameObject.FindGameObjectsWithTag("Tower");

        foreach (GameObject towe in towers)
            Debug.Log(towe.name);
    }

    void SlowUpdate(){
        arrayClean();
    }

    public void arrayClean(){
        List<GameObject> towerList = new List<GameObject>();
        foreach(GameObject tower in towers){
            if(tower != null){
                towerList.Add(tower);
            }
        }

        if(towerList!=null){
            towers = towerList.ToArray();
        }
    }

    public GameObject[] getetowesarray(){
        return towers;
    }

    public int getamountoftowers(){
        return towers.Length + 1;
    }

    // Maximum towers in the scen. is set in towerplacement by passing thoue here to make it easy to find.
    public int getMaxtowers(){
        return towemax;
    }

    public void setMaxtowers(int _inputvalue){
        towemax = _inputvalue;
    }
}
