using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gardenerstats : MonoBehaviour
{
    // Basic gardener stats updater
    // This script is setting the parameters / stats for the basic gardener
    // This script is updateing the enemystoragescript thats expectet to keep stats of all enemyes in a standarasied way.

    private int Healthslider = 10;

    private int damage     = 5;

    public float firerate  = 1;

    public int killvalue   = 3;
    public int brains      = 1;
    public int seeds       = 2;

    public int range       = 10;

    void Start()
    {
        GetComponent<Enemystorage>().sethelht2(Healthslider);
        GetComponent<Enemystorage>().setfirerate(firerate);
        GetComponent<Enemystorage>().setkillvalue(killvalue);
        GetComponent<Enemystorage>().setbrainsvalue(brains);
        GetComponent<Enemystorage>().setseedsvalue(seeds);
        GetComponent<Enemystorage>().setRange(range);
        GetComponent<Enemystorage>().setDamage(damage);
    }
}
