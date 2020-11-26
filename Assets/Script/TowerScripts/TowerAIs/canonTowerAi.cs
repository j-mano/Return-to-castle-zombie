using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonTowerAi : MonoBehaviour
{
    public bool isaktiv;
    int range = 30, firerate = 2, damage = 0;

    float timelastfired;
    public Transform target;
    public Sprite sprite;

    GameObject canonball, gameTarget, shotingtarget, gamehandler;

    void Start()
    {
        load();
    }

    void load(){
        timelastfired = Time.time;
        gamehandler   = GameObject.FindGameObjectWithTag("GameHandler");
    }

    void Update()
    {
        // Checking if the tower is aktiv or not from the standardstatsscript
        isaktiv     = GetComponent<getTowerInfo>().getaiaktiv();

        if(isaktiv == true){
            updateParameters();
            aiupdaate();
        }
    }

    void updateParameters(){
        range         = gameObject.GetComponent<getTowerInfo>().gettowerrange();
        firerate      = gameObject.GetComponent<getTowerInfo>().getTowerFireRate();
        damage        = gameObject.GetComponent<getTowerInfo>().getdamage();
    }

    // Update if tower is aktiv.
    void aiupdaate(){
        updateTarget();

        if (gameTarget != null){
            // stops the tower to fire outside its allowd firerate
            if (timelastfired + firerate < Time.time){
                firecanonball();
                timelastfired = Time.time;
            }
        }
    }

    // Taking out the closest enemy on the map to the tower instance. Null means that no target exist or are out of range
    public void updateTarget(){
        if(gameTarget == null){
            GameObject[] enemies    = gamehandler.GetComponent<enemiesInScene>().getenemiesarray();
        
            float shortestDistance   = Mathf.Infinity;

            GameObject nearestEnemy  = null;

            foreach (GameObject enemy in enemies){ 
                if(enemy != null){
                    float distanstoenemy = Vector2.Distance(transform.position, enemy.transform.position);

                    if (distanstoenemy < shortestDistance){
                        shortestDistance = distanstoenemy;
                        nearestEnemy     = enemy;
                    }
                }
            }

            if (nearestEnemy != null && shortestDistance <= range){
                gameTarget  = nearestEnemy;
            }
        }
        else{
            float distanstotarget = Vector2.Distance(transform.position, gameTarget.transform.position);

            if(distanstotarget > range){
                gameTarget = null;
            }
        }
    }

    // Create a gameobject / canonball
    void firecanonball(){
        canonball  = new GameObject("Canonball");

        SpriteRenderer renderer = canonball.AddComponent<SpriteRenderer>();

        renderer.sortingOrder           = 4;
        renderer.sprite                 = sprite;
        canonball.transform.localScale  = canonball.transform.localScale * 2;
        canonball.transform.position    = this.gameObject.transform.position;

        // each canonball gets it own target.
        shotingtarget = gameTarget;

        // Setting a fixt framerate for updating the postition of the canonball
        InvokeRepeating("canonBallPath", 0, 0.03f);
    }

    // Canonballpath / Moving the canonball to the target and deal damage if it hits. if the target is killd before it hits the target is it destroyd.
    void canonBallPath(){
        float step = 20f * Time.deltaTime;

        if(shotingtarget == null){
            CancelInvoke ("canonBallPath");
            Destroy(canonball);
        }
        else{
            canonball.transform.position = Vector2.MoveTowards(canonball.transform.position, shotingtarget.transform.position ,step);

            float distancex = shotingtarget.transform.position.x - canonball.transform.position.x;
            float distanceY = shotingtarget.transform.position.y - canonball.transform.position.y;

            if(distancex < 0.1 && distanceY < 0.1){
                damagetarget(shotingtarget);
                CancelInvoke ("canonBallPath");
                Destroy(canonball);
            }
        }
    }

    // the function thats sends the damage in this script
    void damagetarget(GameObject enemytodamage){
        enemytodamage.GetComponent<Enemystorage>().substracthehlt(damage);
    }
}
