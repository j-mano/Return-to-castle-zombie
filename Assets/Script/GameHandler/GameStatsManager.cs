using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
     // keep track on how many zombies that have been killd

    public int killdPlants = 0;

    void Start()
    {
        killdPlants = 0;
    }

    public int getkilldZombies(){
        return killdPlants;
    }

    public void addkilldZombies(int killdzombie){
        killdPlants = killdPlants + killdzombie;
    }
}
