using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrenchStats : MonoBehaviour
{
    public int maxHealth    = 600;

    public int towerCost    = 100;

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
