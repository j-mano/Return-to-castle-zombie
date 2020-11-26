using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerTower : MonoBehaviour
{
    // Hower Tower stats updater
    // This script is setting the parameters / stats for the Hower Tower
    // The parameters thats are updated are in towerinfo thats are suppted on each tower
    public int maxHealth = 100;
    public int towerCost = 10;
    public int seedsCost = 0;

    public int range = 15;
    public int firerate = 1;
    public string Type = "Hower";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        GetComponent<getTowerInfo>().setType(Type);
    }
}
