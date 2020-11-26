using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryFloverStats : MonoBehaviour
{
    // Basic flower / angry flower stats updater
    // This script is setting the parameters / stats for the basic flower enemy
    // This script is updateing the enemystoragescript thats expectet to keep stats of all enemyes in a standarasied way.

    public int Healthslider = 20;
    private float firerate  = 2;
    private int killvalue = 1, brains = 1, seeds = 0, range = 2, damage = 2;

    // Sets the values in enemystorage.
    void Start()
    {
        gameObject.GetComponent<Enemystorage>().sethelht2(Healthslider);
        gameObject.GetComponent<Enemystorage>().setfirerate(firerate);
        gameObject.GetComponent<Enemystorage>().setkillvalue(killvalue);
        gameObject.GetComponent<Enemystorage>().setbrainsvalue(brains);
        gameObject.GetComponent<Enemystorage>().setseedsvalue(seeds);
        gameObject.GetComponent<Enemystorage>().setRange(range);
        gameObject.GetComponent<Enemystorage>().setDamage(damage);
    }
}
