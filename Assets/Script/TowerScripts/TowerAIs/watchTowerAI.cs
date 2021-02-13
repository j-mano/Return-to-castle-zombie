using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watchTowerAI : MonoBehaviour
{
    float range = 15f, timelastfired;
    public int firerate = 1;
    private int damage;
    public Sprite sprite;
    public Transform target;
    GameObject gameTarget, gamehandler;
    bool isaktiv;
    Vector2 towerpos;
    void Start()
    {
        load();
    }

    void load(){
        gamehandler     = GameObject.FindGameObjectWithTag("GameHandler");
        timelastfired   = Time.time;
        InvokeRepeating("Colorreset", 0, firerate);
    }

    // Update is called once per frame
    void Update()
    {
        isaktiv = GetComponent<getTowerInfo>().getaiaktiv();

        if(isaktiv == true){
            aiupdaate();
            updateParameters();
        }
    }

    void updateParameters(){
        range       = GetComponent<getTowerInfo>().gettowerrange();
        firerate    = GetComponent<getTowerInfo>().getTowerFireRate();
        damage      = GetComponent<getTowerInfo>().getdamage();
    }

    void aiupdaate(){
        updateTarget();

        if (gameTarget != null)
            shootEnemy();
    }

    public void updateTarget(){
        if(gameTarget == null){
            //GameObject[] enemies = gamehandler.GetComponent<enemiesInScene>().getenemiesarray();

            float shortestDistance = Mathf.Infinity;

            GameObject nearestEnemy = null;
            foreach (GameObject enemy in gamehandler.GetComponent<enemiesInScene>().getenemiesarray())
            {
                if(enemy != null){
                    float distanstoenemy = Vector2.Distance(transform.position, enemy.transform.position);

                    if (distanstoenemy < shortestDistance )
                    {
                        shortestDistance = distanstoenemy;
                        nearestEnemy = enemy;
                    }
                }
            }
            
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target      = nearestEnemy.transform;
                gameTarget  = nearestEnemy;
            }
        }
        else{
            float distanstoenemy = Vector2.Distance(transform.position, gameTarget.transform.position);

            if(distanstoenemy > range){
                target      = null;
                gameTarget  = null;
            }
        }
    }

    void shootEnemy(){
        float distanstoenemy = Vector2.Distance(transform.position, gameTarget.transform.position);

        if(distanstoenemy <= range){
            // shotnemney is check with the fps cunter. this is statemen takes when tower is last fired and checks so tower fires after the cooldown is ower.
            if (timelastfired + firerate <= Time.time){
                gameTarget.GetComponent<Enemystorage>().substracthehlt(damage);
                animatearrow();
                toweranimation();

                // Sets time when fired last time
                timelastfired = Time.time;
            }
        }
    }

    void toweranimation(){
        // Shows whats tower thats fire
        SpriteRenderer sr;
        sr = GetComponent<SpriteRenderer>();
        sr.material.SetColor("_Color", Color.red);
    }

    void Colorreset(){
        SpriteRenderer sr;
        sr = GetComponent<SpriteRenderer>();
        sr.material.SetColor("_Color", Color.white);
    }

    void animatearrow(){
        //put arrow where enemy are when damaged

        GameObject go   = new GameObject("Arrow");
        GameObject go2  = new GameObject("Arrow");

        // Taging the arrows. Used to get the amount of arrows in the cleaning.
        go2.gameObject.tag  = "arrow";
        go.gameObject.tag   = "arrow";

        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer                = go2.AddComponent<SpriteRenderer>();

        // set potition the render layer prioties.
        renderer.sortingOrder = 3;

        // set rotation, potition and size of arrow
        go.transform.position       = gameTarget.transform.position;
        go2.transform.position      = gameTarget.transform.position;
        go.transform.Rotate(0,0,160f);
        go2.transform.Rotate(0,0,160f);
        go.transform.localScale     = new Vector3(0.3f,0.3f,0.3f);
        go2.transform.localScale    = new Vector3(0.3f,0.3f,0.3f);

        renderer.sprite = sprite;
    }
}
