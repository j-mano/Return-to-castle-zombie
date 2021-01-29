using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCleaning : MonoBehaviour
{
    GameObject[] arrowArray;

    void Start()
    {
        InvokeRepeating("arrowcleaner", 0, 0.5f);
    }

    // Cleans up arrows if to many exist on the map.
    void arrowcleaner(){
        arrowArray = GameObject.FindGameObjectsWithTag("arrow");

        if(arrowArray != null){
            int arrowsabove50 = arrowArray.Length - 50;
            if(arrowsabove50 > 0){
                for(int i = 0; i <= arrowsabove50; i++){
                        Destroy(arrowArray[i]);
                }
            }
        }
    }
}
