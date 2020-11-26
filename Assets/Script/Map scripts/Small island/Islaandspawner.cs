using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Islaandspawner : MonoBehaviour
{   
    GameObject basicargblomma, ondskefullblomma, Flygandeblomma, MechaGnome, flowerpot, forrestranger, Ent;

    // Spawnformat Size X, Size y, Pos x, Pos y
    float[] spawnZoneleft   = {1f, 16f, -13f, -8f};
    float[] spawnZonetop    = {22f, 1f, -13f, 8f};
    float[] spawnZoneBottom = {22f, 1f, -13f, -8f};
    float[] spawnZoneright   = {1f, 16f, 13f, -8f};
    
    public int dificulty = 1;
    private int currentlevel = 0;

    private bool bosslevel = false;

    GameObject GameHandler;

    void Start()
    {
        load();

        InvokeRepeating("spawner", 15, 0.1f);
    }

    void load(){
        GameHandler         = GameObject.FindGameObjectWithTag("GameHandler");
        GameHandler.GetComponent<LevelHandler>().setmaxlevel(1);
    }

    void spawner(){
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemyTag");

        GameObject[] enemies;
        enemies = GameHandler.GetComponent<enemiesInScene>().getenemiesarray();
        
        dificulty       = PlayerPrefs.GetInt("DificultyInt");
        currentlevel    = GameHandler.GetComponent<LevelHandler>().getCurrentLevel();

        if(bosslevel == false){
            if(currentlevel == 1)
                lv1Spawner(enemies);
            else
                lv1Spawner(enemies);
        }
        else{
            lv1Spawner(enemies);
        }
    }

    void lv1Spawner(GameObject[] enemies){
        float amountofenimes;
        float[] temparray = randomize_Green_Desert_Location();

        amountofenimes = 2 + (dificulty * (Time.timeSinceLevelLoad * 0.1f));
        
        if(enemies.Length < amountofenimes){
            GetComponent<initateEnemies>().intateFlygandeblomma(temparray[0],temparray[1]);
        }
    }

    // Ej Färdig. temp för nu
    public float[] randomizegreenlocation(){
        float[] temparray = new float[]{0,0};

        //Randomize betwene top and left zone
        int temp = Random.Range(0,2);

        // 0 = top spawn, 1 = left zone
        if(temp == 1){
            temparray[0] = Random.Range(spawnZoneleft[2], (spawnZoneleft[2] + spawnZoneleft[0]));
            temparray[1] = Random.Range(spawnZoneleft[3], spawnZoneleft[3] + spawnZoneleft[1]);
        }
        else
        {
            temparray[0] = Random.Range(spawnZonetop[2], (spawnZonetop[2] + spawnZonetop[0]));
            temparray[1] = Random.Range(spawnZonetop[3], spawnZonetop[3] + spawnZonetop[1]);
        }

        return temparray;
    }

    public float[] randomizedesertlocation(){
        float[] temparray = new float[]{0,0};

        temparray[0] = Random.Range(spawnZoneBottom[2], (spawnZoneBottom[2] + spawnZoneBottom[0]));
        temparray[1] = Random.Range(spawnZoneBottom[3], spawnZoneBottom[3] + spawnZoneBottom[1]);

        return temparray;
    }

    public float[] randomize_Green_Desert_Location(){
        float[] temparray = new float[]{0,0};

        //Randomize betwene top and left zone
        int temp = Random.Range(0,2);

        // 0 = top spawn, 1 = left zone
        if(temp == 1){
            temparray = randomizegreenlocation();
        }
        else
        {
            temparray = randomizedesertlocation();
        }

        return temparray;
    }
}
