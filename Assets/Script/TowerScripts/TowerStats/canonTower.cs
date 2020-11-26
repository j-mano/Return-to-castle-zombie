using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonTower : MonoBehaviour
{
    // canon tower stats updater
    // This script is setting the parameters / stats for the canon tower
    // The parameters thats are updated are in towerinfo thats are suppted on each tower
    public int maxHealth        = 50;
    public int towerCost        = 10;
    public int towercostseeds   = 0;
    public int range            = 30;
    public int firerate         = 5;
    public int damage           = 20;

    void Start()
    {
        gameObject.GetComponent<getTowerInfo>().settowerrange(range);
        gameObject.GetComponent<getTowerInfo>().setTowercost(towerCost);
        gameObject.GetComponent<getTowerInfo>().setTowercostseeds(towercostseeds);
        gameObject.GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        gameObject.GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        gameObject.GetComponent<getTowerInfo>().settowerrange(range);
        gameObject.GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        gameObject.GetComponent<getTowerInfo>().setdamage(damage);
    }
}
