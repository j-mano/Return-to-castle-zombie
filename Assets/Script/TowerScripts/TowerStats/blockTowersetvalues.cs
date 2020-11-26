using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockTowersetvalues : MonoBehaviour
{
    // Block tower stats updater
    // This script is setting the parameters / stats for the Block tower
    // The parameters thats are updated are in towerinfo thats are suppted on each tower
    public int maxHealth = 50;

    public int towerCost = 1;

    public int range = 0;

    public int firerate = 0;
    
    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
    }
}
