using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonStats : MonoBehaviour
{
    // Ballon flower stats updater
    // This script is setting the parameters / stats for the ballon enemy
    // This script is updateing the enemystoragescript thats expectet to keep stats of all enemyes in a standarasied way.
    private int Healthslider = 20;

    private int damage     = 4;

    public float firerate  = 3;

    public int killvalue   = 2;
    public int brains      = 2;
    public int seeds       = 1;

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
