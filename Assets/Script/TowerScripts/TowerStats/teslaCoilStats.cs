using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teslaCoilStats : MonoBehaviour
{
    public int maxHealth = 25;

    public int towerCost = 0;
    public int towercostseeds = 1;

    public int range = 10;

    public int firerate = 1;
    
    public int damage = 10;

    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setTowercostseeds(towercostseeds);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        GetComponent<getTowerInfo>().setdamage(damage);
    }
}
