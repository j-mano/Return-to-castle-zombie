using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool ispaused;
    GameObject[] enemies, Towers;
    GameObject gamehandler;

    void Start()
    {
        load();
    }

    void load(){
        ispaused = true;
        gamehandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    public bool getIfPaus(){
        bool returnvalue = false;

        returnvalue = ispaused;
        
        return returnvalue;
    }

    public void resumePaus(){
        ispaused = !ispaused;

        if(ispaused){
            resumeAll();
        }
        else{
            pauseall();
        }

        Debug.Log(ispaused);
    }

    void resumeAll(){
        resumespawner();
        resumelltower();
        resumellenemies();

        CancelInvoke("pausespawner");
        CancelInvoke("pausellenemies");
        CancelInvoke("pauselltower");
    }

    void pauseall(){
        InvokeRepeating("pausespawner", 0, 0.3f);
        InvokeRepeating("pausellenemies", 0, 0.3f);
        InvokeRepeating("pauselltower", 0, 0.3f);
    }

    void pausellenemies(){
        loadinenemies();

        if(enemies != null){
            foreach (GameObject enemy in enemies){
                enemy.GetComponent<Enemystorage>().SetAiActiv(false);
            }
        }
    }

    void pauselltower(){
        loadtower();

        if(enemies != null){
            foreach (GameObject Towerr in Towers){
                Towerr.GetComponent<getTowerInfo>().setaiaktiv(false);
            }
        }
    }

    void pausespawner(){
        gamehandler.GetComponent<LevelHandler>().enabled = true;
    }

    void resumellenemies(){
        loadinenemies();

        if(enemies != null){
            foreach (GameObject enemy in enemies){
                enemy.GetComponent<Enemystorage>().SetAiActiv(true);
            }
        }
    }

    void resumelltower(){
        loadtower();
        
        if(enemies != null){
            foreach (GameObject Towerr in Towers){
                Towerr.GetComponent<getTowerInfo>().setaiaktiv(true);
            }
        }
    }

    void resumespawner(){
        gamehandler.GetComponent<LevelHandler>().enabled = true;
    }

    void loadinenemies(){
        enemies = gamehandler.GetComponent<enemiesInScene>().getenemiesarray();
    }

    void loadtower(){
        Towers = gamehandler.GetComponent<towersInScen>().getetowesarray();
    }
}
