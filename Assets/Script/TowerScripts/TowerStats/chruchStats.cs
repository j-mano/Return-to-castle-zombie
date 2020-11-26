using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chruchStats : MonoBehaviour
{
    public int maxHealth = 150;

    public int towerCost = 5;

    public int range = 0;

    public int firerate = 0;

    public int towerseedCost = 2;

    void Start()
    {
        gameObject.GetComponent<getTowerInfo>().setTowercost(towerCost);
        gameObject.GetComponent<getTowerInfo>().setcurrenthelt(maxHealth);
        gameObject.GetComponent<getTowerInfo>().settowerrange(range);
        gameObject.GetComponent<getTowerInfo>().setTowerFireRate(firerate);
        gameObject.GetComponent<getTowerInfo>().setTowercostseeds(towerseedCost);
    }
}
