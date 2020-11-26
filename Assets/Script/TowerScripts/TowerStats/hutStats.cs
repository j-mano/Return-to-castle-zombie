using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hutStats : MonoBehaviour
{
    // Hut health house stats updater
    // This script is setting the parameters / stats for the hut heacht house
    // The parameters thats are updated are in towerinfo thats are suppted on each tower

    private int maxHealth = 20;
    private int towerCost = 0;
    private int towercostseeds = 1;

    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setTowercostseeds(towercostseeds);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
    }
}
