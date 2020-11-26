using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerZombieStats : MonoBehaviour
{
    // Zombie tower stats updater
    // This script is setting the parameters / stats for the Zombie tower
    // The parameters thats are updated are in towerinfo thats are suppted on each tower
    public int maxHealth = 35;

    public int towerCost = 7;

    public int towercostseeds = 0;

    public int range = 20;

    public int firerate = 2;

    public int damage = 10;
    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        GetComponent<getTowerInfo>().setdamage(damage);
    }

    public int getbraincost(){
        return towerCost;
    }

    public int getseedscost(){
        return towercostseeds;
    }
}
