using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmilAi : MonoBehaviour
{
    public bool isaktiv;

    void Update()
    {
        // Checking if the tower is aktiv or not from the standardstatsscript
        isaktiv     = GetComponent<getTowerInfo>().getaiaktiv();

        if(isaktiv == true)
            aiupdaate();
    }

    // Update if tower is aktiv.
    void aiupdaate(){
        updateTarget();
    }

    // Taking out the closest enemy on the map to the tower instance. Null means that no target exist or are out of range
    public void updateTarget(){
        GameObject[] enemies    = GameObject.FindGameObjectsWithTag("enemyTag");
        Vector2 treadmilPos     = gameObject.transform.position;

        float treadmilWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float treadmilHeigt = GetComponent<SpriteRenderer>().bounds.size.y;
        
        foreach (GameObject enemy in enemies){ 
            if(enemy.transform.position.x <= (treadmilPos.x + (treadmilWidth / 2)) && enemy.transform.position.x >= (treadmilPos.x - (treadmilWidth / 2))){
                if(enemy.transform.position.y <= (treadmilPos.y + (treadmilHeigt / 2)) && enemy.transform.position.y >= (treadmilPos.y - (treadmilHeigt / 2))){
                    enemy.transform.position = new Vector2(enemy.transform.position.x + 2, enemy.transform.position.y + 2);
                }
            }
        }
    }
}
