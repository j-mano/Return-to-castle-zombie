using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using System.Threading;
using System.Threading.Tasks;

public class AiPath : MonoBehaviour
{
    public Transform target;
    private Transform towetarget, currenttarget, shotingtarget;
    private float timelastfirerd;
    // casesetter 0 = goes directly to castle and ignore everything else 1 = agressiv and attaking towers.
    int enemyAiModeSetter = 0, currentWaypoint = 0;
    GameObject castle, GameHandler, canonball;
    public float range = 15f, speed = 300f, nextwaypoint = 3f;
    public Animator animator; 
    Path path;
    Seeker seeker;
    Rigidbody2D rg;
    GameObject[] Towers;
    public Sprite sprite;

    async void Start(){
        InvokeRepeating("updatepath", 0f, 0.5f);
        await load();
    }

    async void Update()
    {
        if(gameObject.GetComponent<Enemystorage>().getAiActiv()){
            await flippingSpriteInDir();
            towerisdestroyd();
            aiDirwaypoint();
        }
    }

    void OnDestroy()
    {
        Debug.Log(this.name + "Is Killed");
    }

    void aiDirwaypoint(){
        if(path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count){
            //reached = true;
            return;
        }
        else{
            //reached = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rg.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if(currenttarget != null){
            float DistanceToTarget = Vector2.Distance(rg.position, currenttarget.transform.position);

            if(DistanceToTarget - 0.5f >= gameObject.GetComponent<Enemystorage>().getRange()){
                rg.AddForce(force);
            }
            else if(DistanceToTarget < gameObject.GetComponent<Enemystorage>().getRange()){
                damageTarget();
            }

            float distance = Vector2.Distance(rg.position,path.vectorPath[currentWaypoint]);

            if((distance + 1.5) < nextwaypoint){
                currentWaypoint++;
            }
        }
        else{
            Debug.Log("no target found. Says: " + gameObject);
        }
    }

    async Task flippingSpriteInDir(){
        // Fliping the sprite to face the direction it moves
        if(rg != null){
            if(rg.velocity.x >= 0.01f)
                transform.localRotation = Quaternion.Euler(0, 180, 0); 
            else if (rg.velocity.x <= -0.01f)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    async Task load(){
        range   = gameObject.GetComponent<Enemystorage>().getRange();

        seeker  = GetComponent<Seeker>();
        rg      = GetComponent<Rigidbody2D>();

        castle      = GameObject.FindGameObjectWithTag("castle");
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    void updatepath(){
        if(enemyAiModeSetter == 0){
            currenttarget = target;

            if(seeker.IsDone())
            seeker.StartPath(rg.position, target.position, OnPathComplete);
        }
        
        if(enemyAiModeSetter == 1){
            if(towetarget == null)
                updateTarget();

            currenttarget = towetarget;

            if(seeker.IsDone())
                seeker.StartPath(rg.position, towetarget.position, OnPathComplete2);
        }
    }

    void towerisdestroyd(){
        if(GameHandler.GetComponent<towerPlcement>().gettowerrecentlydestroyd()){
            enemyAiModeSetter = 0;
        }
    }

    void OnPathComplete(Path p){
        if(!p.error){
            float DistanceWaypoint_Castle = 0;

            try{
                DistanceWaypoint_Castle = Vector2.Distance(castle.transform.position, p.vectorPath[p.vectorPath.Count - 1]);
            }
            catch{
                Debug.Log("Enemy AI Target lost");
            }

            if(DistanceWaypoint_Castle <= 1.5f){
                path = p;
                currentWaypoint = 0;
                enemyAiModeSetter = 0;
            }
            else{
                Debug.Log("Castle cant be reacht");
                enemyAiModeSetter = 1;
            }
        }
        else{
            Debug.Log(p.error);
        }
    }

    void OnPathComplete2(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
        else{
            Debug.Log(p.error);
        }
    }

    // updating witch tower thats are the closes to that specific instance of the enemy unit
    void updateTarget(){
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (GameObject tower in GameHandler.GetComponent<towersInScen>().getetowesarray())
        {
            float distanstoenemy = Vector2.Distance(transform.position, tower.transform.position);

            if (distanstoenemy < shortestDistance )
            {
                shortestDistance = distanstoenemy;
                nearestEnemy = tower;
            }
        }
        
        if (nearestEnemy != null){
            towetarget = nearestEnemy.transform;
        }
    }

    // Damage the target. just that damaging the target if it in range
    void damageTarget(){
        float currenttime       = Time.time;

        float timesincefired    = currenttime - timelastfirerd;

        //animator.SetBool("attaking", false);

        if (timesincefired >= gameObject.GetComponent<Enemystorage>().getFireRate()){
            //animator.SetBool("attaking", true);

            if (enemyAiModeSetter == 0){
                //castle.GetComponent<houseObjektScript>().housedamage(gameObject.GetComponent<Enemystorage>().getDamage());
                firecanonball();
                timelastfirerd = Time.time;
            }
            
            if(enemyAiModeSetter == 1){
                //currenttarget.GetComponent<getTowerInfo>().substracthelht(gameObject.GetComponent<Enemystorage>().getDamage());
                firecanonball();
                timelastfirerd = Time.time;
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
        shotingtarget = target;

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
                damagetarget2(shotingtarget);
                CancelInvoke ("canonBallPath");
                Destroy(canonball);
            }
        }
    }

    // the function thats sends the damage in this script
    void damagetarget2(Transform enemytodamage){
        if (enemyAiModeSetter == 0){
                castle.GetComponent<CastleManager>().housedamage(gameObject.GetComponent<Enemystorage>().getDamage());
                timelastfirerd = Time.time;
            }
            
        if(enemyAiModeSetter == 1){
                enemytodamage.GetComponent<getTowerInfo>().substracthelht(gameObject.GetComponent<Enemystorage>().getDamage());
                timelastfirerd = Time.time;
            }
    }
}
