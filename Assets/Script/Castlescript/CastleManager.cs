using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading;
using System.Threading.Tasks;

public class CastleManager : MonoBehaviour
{
    public float starthealth = 100, currentHouseHealth;

    bool dead;

    GameObject[] villagers;
    GameObject zombie;

    public Slider healthslider;

    public Healthslider g;

    void Start()
    {
        currentHouseHealth = starthealth;
        
        try{
            zombie = Resources.Load ("Prefab/Villagers/Zombie") as GameObject;
        }
        catch{
            Debug.Log("Failed to load villager prefab from disk. Does the prefab exist at Prefab/Villagers/Zombie?");
        }
    }

    // Update the ui healthh slider.
    void Update()
    {
        healthRepesSentationManagers();
    }

    public float getCastleHealth(){
        return currentHouseHealth;
    }

    // subtrakt healht from the castle. Used to by towers and are calld from the towers ai.
    public void housedamage(int damage){
        Task t3 = Task.Run( () => {
            currentHouseHealth = currentHouseHealth - damage;
        });
    }

    // adding healht to the castle. Used to by towers and are calld from the towers ai.
    public void addhealt(int addhealt){
        Task t3 = Task.Run( () => {
            currentHouseHealth = currentHouseHealth + addhealt;

            if(currentHouseHealth > 100){
                currentHouseHealth = 100;
                Debug.Log("Max Health Reacht");
            }
        });
    }

    // show grafikly the health of the castle with objects
    void healthRepesSentationManagers(){
            villagers = GameObject.FindGameObjectsWithTag("villagers");

            if (currentHouseHealth >= starthealth * 0.95)
                setAmountOfZombies(5);
            else if (currentHouseHealth >= starthealth * 0.75)
                setAmountOfZombies(4);
            else if (currentHouseHealth >= starthealth * 0.50)
                setAmountOfZombies(3);
            else if (currentHouseHealth >= starthealth * 0.25)
                setAmountOfZombies(2);
            else if (currentHouseHealth >= starthealth * 0.01)
                setAmountOfZombies(1);
            else if (currentHouseHealth == 0)
                setAmountOfZombies(0);
    }

    // Spawn in or destroy zombies dependent on the number sent in. Shoud be used with a healthmanager.
    void setAmountOfZombies(int amountOfZombies){
        if(villagers.Length < amountOfZombies)
            Instantiate(zombie, this.transform.position, Quaternion.identity);
        else if(villagers.Length > amountOfZombies)
            Destroy(villagers[villagers.Length - 1]);
    }
}
