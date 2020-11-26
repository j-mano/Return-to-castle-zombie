using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treadmilStats : MonoBehaviour
{
    public int maxHealth    = 25;

    public int towerCost    = 10;

    public int range        = 0;

    public int firerate     = 0;

    void Start()
    {
        GetComponent<getTowerInfo>().setTowercost(towerCost);
        GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        GetComponent<getTowerInfo>().settotalhelt(maxHealth);
        GetComponent<getTowerInfo>().settowerrange(range);
        GetComponent<getTowerInfo>().setTowerFireRate(firerate);
    }
}
