using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemystorage : MonoBehaviour
{
    // Defult values of an enemy unit
    public float starthehth = 20, currenthealht, firerate = 2, range = 0;
    public int killvalue = 1, brains = 1, seeds = 0, damage = 2;
    float timelastfirerd;
    bool aiactiv = true;
    GameObject castle, GameHandler;

    void Start()
    {
        // This script is a defultscript for all enemies that give them defult stats and comminicate with all othe part of the game.
        currenthealht = starthehth;
        timelastfirerd = Time.time;
    }

    void Update()
    {
        enemydead();

        castle      = GameObject.FindGameObjectWithTag("castle");
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    // Alot of metods to keep track of all stats of an enemy object.
    public float gethehlt(){
        return currenthealht;
    }

    public float getRange(){
        return range;
    }

    public bool getAiActiv(){
        return aiactiv;
    }

    public void SetAiActiv(bool _inputActivbool){
        aiactiv =_inputActivbool;
    }

    public void setRange(float rangeinput){
        range = rangeinput;
    }

    public float getFireRate(){
        return firerate;
    }

    public int getDamage(){
        return damage;
    }

    public void setDamage(int damageInput){
        damage = damageInput;
    }

    public void substracthehlt(float h){
        currenthealht = currenthealht - h;
    }

    public void sethelht2(float h){
        currenthealht = h;
    }

    public void setkillvalue(int inputkillvalue){
        killvalue = inputkillvalue;
    }

    public void setbrainsvalue(int inputbrainsvalue){
        brains = inputbrainsvalue;
    }

    public void setseedsvalue(int inputseedsvalue){
        seeds = inputseedsvalue;
    }

    public void setfirerate(float firerateinput){
        firerate = firerateinput;
    }

    // keep it for now but has been replaced by ai script
    void damageTarget(){
        float distanstocastle   = Vector2.Distance(transform.position, castle.transform.position);

        float currenttime       = Time.time;

        float timesincefired    = currenttime - timelastfirerd;

        if (distanstocastle <= 1.5 && timesincefired >= firerate){
            castle.GetComponent<CastleManager>().housedamage(damage);
            timelastfirerd = Time.time;
        }
    }

    // Checks if enemy is alive or not and destroys itself if dead.
    void enemydead(){
        if(currenthealht <= 0){
            FindObjectOfType<audiomanager>().Play("PlantDeath");

            GameHandler.GetComponent<enemiesInScene>().removeenemie();
            ondeadthupdatestats();
            destroyobject();
        }
    }

    // Destroy object and everything related to it.
    void destroyobject(){
        Destroy(gameObject);
    }

    // Updatdesstats as it shoud when the object dies.
    async void ondeadthupdatestats(){
        await GameHandler.GetComponent<GameStatsManager>().addkilldZombiesAsync(killvalue);

        GameHandler.GetComponent<Economy>().addbrains(brains);
        GameHandler.GetComponent<Economy>().addseeds(seeds);
    }
}
