using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertilandSpawner : MonoBehaviour
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
        InvokeRepeating("levelsetter", 14.8f, 100f);
    }

    void load(){
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        GameHandler.GetComponent<LevelHandler>().setmaxlevel(6);
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
            else if(currentlevel == 2)
                lv2Spawner(enemies);
            else if(currentlevel == 3)
                lv3Spawner(enemies);
            else if(currentlevel == 4)
                lv4Spawner(enemies);
            else if(currentlevel == 5)
                lv5Spawner(enemies);
            else if(currentlevel == 6)
                lv6Spawner(enemies);
            else
                lv1Spawner(enemies);
        }
        else{
            lv6Spawner(enemies);
        }
    }

    void levelsetter(){
        currentlevel = currentlevel + 1;
        GameHandler.GetComponent<LevelHandler>().setCurrentLevel(currentlevel);

        Debug.Log("Next level");

        if(currentlevel >= 6){
            restartlevels();
            Debug.Log("Max level reacht. reset from lvl 1 with the extra time dificulty");
        }
    }

    void restartlevels(){
        currentlevel = 0;
    }

    void lv1Spawner(GameObject[] enemies){
        float amountofenimes;
        float[] GreenArray      = randomizegreenlocation();

        amountofenimes = 2 + (dificulty * (Time.timeSinceLevelLoad * 0.1f));
        
        if(enemies.Length < amountofenimes){
            GetComponent<initateEnemies>().intatebasicargblomma(GreenArray[0],GreenArray[1]);
        }
    }

    void lv2Spawner(GameObject[] enemies){
        float amountofenimes;
        float[] GreenArray      = randomizegreenlocation();
        float[] DesertArray     = randomizedesertlocation();

        amountofenimes = 4 + (dificulty * (Time.time * 0.1f));

        if(enemies.Length < amountofenimes){
            GetComponent<initateEnemies>().intatebasicargblomma(GreenArray[0],GreenArray[1]);
            GetComponent<initateEnemies>().intateondskefullblomma(DesertArray[0],DesertArray[1]);
        }
    }

    void lv3Spawner(GameObject[] enemies){
        float amountofenimes;
        float[] GreenArray      = randomizegreenlocation();
        float[] DesertArray     = randomizedesertlocation();

        amountofenimes = 4 + (dificulty * (Time.time * 0.1f));

        if(enemies.Length < amountofenimes){
            GetComponent<initateEnemies>().intateFlygandeblomma(GreenArray[0],GreenArray[1]);
            GetComponent<initateEnemies>().intateondskefullblomma(DesertArray[0],DesertArray[1]);
        }
    }

    void lv4Spawner(GameObject[] enemies){
        float amountofenimes;
        float[] DesertArray     = randomizedesertlocation();

        amountofenimes = 4 + (dificulty * (Time.time * 0.2f));

        if(enemies.Length < amountofenimes){
            GetComponent<initateEnemies>().intateforrestranger(DesertArray[0],DesertArray[1]);
        }
    }

    void lv5Spawner(GameObject[] enemies){
        float amountofenimes;
        float[] GreenArray      = randomizegreenlocation();

        amountofenimes = 4 + (dificulty * (Time.time * 0.2f));

        if(enemies.Length < amountofenimes){
            GetComponent<initateEnemies>().intateflowerpot(GreenArray[0],GreenArray[1]);
        }
    }
    bool first = false;

    void lv6Spawner(GameObject[] enemies){
        float[] Greendesertarry = randomize_Green_Desert_Location();

        CancelInvoke("levelsetter");

        if(first == false){
            first = true;
            GetComponent<initateEnemies>().intateMechaGnome(Greendesertarry[0],Greendesertarry[1]);
        }

        if(enemies.Length <= 0){
            bosslevel = false;
            currentlevel = currentlevel + 1;

            // Achimentsettings mechagnomekill
            PlayerPrefs.SetInt("HasKilledMechagnome", 1);

            InvokeRepeating("levelsetter", 0.5f, 100f);
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
