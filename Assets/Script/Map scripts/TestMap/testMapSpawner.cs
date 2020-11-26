using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMapSpawner : MonoBehaviour
{
    // Gameobject gamehandlingobject and buildings.
    GameObject GameHandler, castle;

    // Enmies relevant to the lvl.
    GameObject basicargblomma, ondskefullblomma, Flygandeblomma, MechaGnome, flowerpot, forrestranger, Ent;

    // Spawnformat Size X, Size y, Pos x, Pos y
    float[] spawnZoneleft   = {1f, 16f, -13f, -8f};
    float[] spawnZonetop    = {22f, 1f, -13f, 8f};
    float[] spawnZoneBottom = {13f, 1f, 0f, -8f};

    int amountofenimes      = 0;

    bool autoheath = false;

    void Start()
    {
        load();
        setCashToHigh();
    }

    void load(){
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        GameHandler.GetComponent<LevelHandler>().setmaxlevel(1);
        castle = GameObject.FindGameObjectWithTag("castle");
    }

    void Update()
    {
        controlls();
        Spawner();
        setCashToHigh();
        autohealth();
    }

    void setCashToHigh(){
        GameHandler.GetComponent<Economy>().setBrains(1000);
        GameHandler.GetComponent<Economy>().setSeeds(1000);
    }

    void controlls(){
        if (Input.GetKeyDown(KeyCode.W)){
            amountofenimes = amountofenimes + 1;
            Debug.Log(amountofenimes);
        }

        if (Input.GetKeyDown(KeyCode.S)){
            amountofenimes = amountofenimes - 1;
            Debug.Log(amountofenimes);
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            castle.GetComponent<CastleManager>().addhealt(100);
            Debug.Log("healht added");
        }

        if (Input.GetKeyDown(KeyCode.A)){
            autoheath = !autoheath;
            Debug.Log("autohelht = " + autoheath);
        }
    }

    void autohealth(){
        if(autoheath == true)
            castle.GetComponent<CastleManager>().addhealt(100);
    }

    void Spawner(){
        GameObject[] enemies;
        enemies = GameHandler.GetComponent<enemiesInScene>().getenemiesarray();
        
        float[] temparray = randomize_Green_Desert_Location();
        
        if(enemies != null){
            if(enemies.Length < amountofenimes){
                
                for(int i = enemies.Length; i <= amountofenimes; i++){
                    GetComponent<initateEnemies>().intatebasicargblomma(temparray[0],temparray[1]);
                }
            }
        }
    }

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
