using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

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

    public async Task addkilldZombiesAsync(int killdzombie){
        killdPlants = killdPlants + killdzombie;
    }
}
