using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTower : MonoBehaviour
{
    // watch tower stats updater
    // This script is setting the parameters / stats for the watchtower
    // The parameters thats are updated are in towerinfo thats are suppted on each tower
    public int maxHealth = 20;

    public int towerCost = 5;
    public int towercostseeds = 0;

    public int range = 5;

    public int firerate = 1;
    
    public int damage = 5;

    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        GetComponent<getTowerInfo>().setdamage(damage);
    }
}
