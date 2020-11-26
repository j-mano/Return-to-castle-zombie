using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechagnomestats : MonoBehaviour
{
    // Basic flower/angry flower stats updater
    // This script is setting the parameters / stats for the basic flower enemy
    // This script is updateing the enemystoragescript thats expectet to keep stats of all enemyes in a standarasied way.

    private int Healthslider = 100;

    private int damage     = 18;

    public float firerate  = 10;

    public int killvalue   = 5;
    public int brains      = 10;
    public int seeds       = 2;

    public int range       = 4;

    public int gamedificultyid = 1;

    // setting the values in the standard script thats holds the values of the enemy. currently enamystorage.
    void Start()
    {
        gamedificultyid = PlayerPrefs.GetInt("DificultyInt");
        
        Healthslider = Healthslider + (10 * gamedificultyid);
        damage       = damage + (3 * gamedificultyid);

        gameObject.GetComponent<Enemystorage>().sethelht2(Healthslider);
        gameObject.GetComponent<Enemystorage>().setfirerate(firerate);
        gameObject.GetComponent<Enemystorage>().setkillvalue(killvalue);
        gameObject.GetComponent<Enemystorage>().setbrainsvalue(brains);
        gameObject.GetComponent<Enemystorage>().setseedsvalue(seeds);
        gameObject.GetComponent<Enemystorage>().setRange(range);
        gameObject.GetComponent<Enemystorage>().setDamage(damage);
    }
}
