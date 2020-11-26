using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villagerAi : MonoBehaviour
{
    GameObject GameHandler;

    private float RotateSpeed = 0.5f;
    private float Radius = 2f;
 
    private Vector2 _centre;
    private float _angle;

    private bool randomdir = false;

    void Start()
    {
        onSpawn();
    }

    void Update()
    {
        villagermovment();
    }

    // praktacly the same as start just one extra step. all functions thats shoud be loaded in then it initilated.
    void onSpawn()
    {
        // Loading everything thats are needed.
        load();

        // Loading dirextion of villager moving around
        randomdirfunction();

        // Spawn sound
        FindObjectOfType<audiomanager>().Play("ZombieSpawn");
    }

    void load()
    {
        RotateSpeed = Random.Range(0f, 1f);

        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        _centre = GameHandler.transform.position;
    }

    // Moving the villager
    void villagermovment()
    {
        if (randomdir == false)
            _angle -= RotateSpeed * Time.deltaTime;
        else
            _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }

    // Randommise the dir of the villagers.
    void randomdirfunction()
    {
        int randomnumber = Random.Range(0, 4);

        if (randomnumber > 1)
            randomdir = true;
        else
            randomdir = false;
    }
    
    // When the villagers are destroyd. Initaltation is handled by GameHandler health manager.
    void OnDestroy()
    {
        // Plays death sound
        try{
            FindObjectOfType<audiomanager>().Play("Zombiedeath");
        }
        catch{
            Debug.Log("Gameobject (Villagers) rips from their places unsafly");
        }
    }
}
