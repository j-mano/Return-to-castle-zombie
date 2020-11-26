using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowmanstats : MonoBehaviour
{
    // Basic arrowman stats updater
    // This script is setting the parameters / stats for the basic arrowman
    // This script is updateing the enemystoragescript thats expectet to keep stats of all enemyes in a standarasied way.

    private int Healthslider = 15;

    private int damage     = 1;

    public float firerate  = 1;

    public int killvalue   = 1;
    public int brains      = 1;
    public int seeds       = 0;

    public int range       = 5;

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
