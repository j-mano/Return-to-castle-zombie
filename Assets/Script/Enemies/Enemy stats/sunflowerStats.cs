using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunflowerStats : MonoBehaviour
{
     // basic flower / angry flower stats kepper

    private int Healthslider = 20;

    private int damage     = 2;

    public float firerate  = 2;

    public int killvalue   = 1;
    public int brains      = 1;
    public int seeds       = 0;

    public int range       = 5;

    // updates the valus of the instance in enemystorage
    void Start()
    {
        setvalues();
    }

    void setvalues(){
        GetComponent<Enemystorage>().sethelht2(Healthslider);
        GetComponent<Enemystorage>().setfirerate(firerate);
        GetComponent<Enemystorage>().setkillvalue(killvalue);
        GetComponent<Enemystorage>().setbrainsvalue(brains);
        GetComponent<Enemystorage>().setseedsvalue(seeds);
        GetComponent<Enemystorage>().setRange(range);
        GetComponent<Enemystorage>().setDamage(damage);
    }
}
