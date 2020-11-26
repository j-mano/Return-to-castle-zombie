using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teslaCoilAi : MonoBehaviour
{
    float range = 15f, timelastfired;
    public int firerate = 0, damage = 0;
    public bool isaktiv, Clean;

    // Target
    Transform target;
    GameObject gameTarget, gamehandler;
    
    LineRenderer lineRenderer;
    // Colour of the beam
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 2;

    private Vector2 rotAnimation;

    void Start()
    {
        Load();
    }

    void Load()
    {
        gamehandler     = GameObject.FindGameObjectWithTag("GameHandler");
        timelastfired   = Time.time;

        lineRenderer = GetComponent<LineRenderer>();

        //lineRenderer.material      = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = lengthOfLineRenderer;
        lineRenderer.sortingOrder  = 3;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1f) }
        );

        lineRenderer.colorGradient = gradient;
    }
    
    void Update()
    {
        isaktiv = GetComponent<getTowerInfo>().getaiaktiv();

        if(isaktiv == true){
            updateParameters();
            aiupdaate();
        }
    }

    void updateParameters(){
        range       = GetComponent<getTowerInfo>().gettowerrange();
        firerate    = GetComponent<getTowerInfo>().getTowerFireRate();
        damage      = GetComponent<getTowerInfo>().getdamage();
    }

    void aiupdaate(){
        updateTarget();

        if (target != null)
            shootEnemy();
        else
            OnDrawGizmosclosetower();
    }

    GameObject nearestEnemy = null;
    public void updateTarget(){
        float shortestDistance  = Mathf.Infinity;

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
            target = nearestEnemy.transform;
            gameTarget = nearestEnemy;
        }
    }

    void shootEnemy(){
        // shotnemney is check with the fps cunter. this is statemen takes when tower is last fired and checks so tower fires after the cooldown is ower.
        if (timelastfired + firerate <= Time.time){
            gameTarget.GetComponent<Enemystorage>().substracthehlt(damage);

            // Sets time when fired last time
            timelastfired = Time.time;
        }

        // Constanly fires at the enemy with laser but only damageing it when firerate says so.
        OnDrawGizmosSelected();
    }

    void OnDrawGizmosSelected() {
        lineRenderer.SetPosition(0, gameObject.transform.position);

        lineRenderer.SetPosition(1, target.transform.position);
        Clean = false;
    }
    
    void OnDrawGizmosclosetower() {
        if(Clean == false){
            lineRenderer.SetPosition(0, gameObject.transform.position);

            lineRenderer.SetPosition(1, gameObject.transform.position);
            Clean = true;
        }
    }
}
