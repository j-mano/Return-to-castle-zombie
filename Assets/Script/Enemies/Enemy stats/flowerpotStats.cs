using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerpotStats : MonoBehaviour
{
    private int Healthslider = 50;

    private int damage     = 3;

    public float firerate  = 3;

    public int killvalue   = 1;
    public int brains      = 2;
    public int seeds       = 1;

    // updates the valus of the instance in enemystorage
    void Start()
    {
        gameObject.GetComponent<Enemystorage>().sethelht2(Healthslider);
        gameObject.GetComponent<Enemystorage>().setfirerate(firerate);
        gameObject.GetComponent<Enemystorage>().setkillvalue(killvalue);
        gameObject.GetComponent<Enemystorage>().setbrainsvalue(brains);
        gameObject.GetComponent<Enemystorage>().setseedsvalue(seeds);
        gameObject.GetComponent<Enemystorage>().setDamage(damage);
    }
}
