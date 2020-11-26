using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombielilystats : MonoBehaviour
{
    // Zombie_lily heacht house stats updater
    // This script is setting the parameters / stats for the hut heacht house
    // The parameters thats are updated are in towerinfo thats are suppted on each tower

    private int maxHealth = 15;
    private int towerCost = 5;
    private int towercostseeds = 0;

    public int range            = 30;
    public int firerate         = 5;
    public int damage           = 20;

    public string Type = "WaterTower";
    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setTowercostseeds(towercostseeds);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().setType(Type);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        GetComponent<getTowerInfo>().setdamage(damage);
    }
}
