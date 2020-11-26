using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initateEnemies : MonoBehaviour
{
    GameObject basicargblomma, ondskefullblomma, Flygandeblomma, MechaGnome, flowerpot, forrestranger, Ent, targetenemie;
    GameObject GameHandler;

    void Start()
    {
        load();
    }

    void load(){
        try{
            basicargblomma      = Resources.Load ("Prefab/Enimeies/AngryFlower")                    as GameObject;
            ondskefullblomma    = Resources.Load ("Prefab/Enimeies/OndBlomma")                      as GameObject;
            Flygandeblomma      = Resources.Load ("Prefab/Enimeies/FlowerBallonBallon")             as GameObject;
            MechaGnome          = Resources.Load ("Prefab/Enimeies/MechaGnome")                     as GameObject;
            flowerpot           = Resources.Load ("Prefab/Enimeies/FlowerpotPlant")                 as GameObject;
            forrestranger       = Resources.Load ("Prefab/Enimeies/ForestRangersingel")             as GameObject;
            Ent                 = Resources.Load ("Prefab/Enimeies/Ent")                            as GameObject;
            
            GameHandler         = GameObject.FindGameObjectWithTag("GameHandler");
        }
        catch{
            Debug.Log("Faild to load enemies");
        }
    }

    void initateEnemie(float posX, float posY){
        Instantiate(targetenemie, new Vector2(posX,posY), Quaternion.identity);
    }
    
    public void intatebasicargblomma(float posX, float posY){
        targetenemie = basicargblomma;
        initateEnemie(posX, posY);
    }

    public void intateondskefullblomma(float posX, float posY){
        targetenemie = ondskefullblomma;
        initateEnemie(posX, posY);
    }

    public void intateFlygandeblomma(float posX, float posY){
        targetenemie = Flygandeblomma;
        initateEnemie(posX, posY);
    }

    public void intateMechaGnome(float posX, float posY){
        targetenemie = MechaGnome;
        initateEnemie(posX, posY);
    }

    public void intateflowerpot(float posX, float posY){
        targetenemie = flowerpot;
        initateEnemie(posX, posY);
    }

    public void intateforrestranger(float posX, float posY){
        targetenemie = forrestranger;
        initateEnemie(posX, posY);
    }

    public void forrestEnt(float posX, float posY){
        targetenemie = Ent;
        initateEnemie(posX, posY);
    }
}
