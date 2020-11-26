using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entStats : MonoBehaviour
{
    // Basic ent stats updater
    // This script is setting the parameters / stats for the basic ent
    // This script is updateing the enemystoragescript thats expectet to keep stats of all enemyes in a standarasied way.
    private int Healthslider = 50;

    private int damage     = 5;

    public float firerate  = 2;

    public int killvalue   = 3;
    public int brains      = 4;
    public int seeds       = 2;

    public int range       = 2;

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
