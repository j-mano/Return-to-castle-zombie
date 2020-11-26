using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupscript : MonoBehaviour
{
    // this script is set to the popupgui thats loaded to all towers. this is setting if an tower shoud be uppgraded or destroyd.
    GameObject selectedtower;

    public void setgameobject(GameObject tower){
        selectedtower = tower;
    }
    
    public void destroy(){
        if(gameObject != null)
            Destroy(selectedtower);

        AstarPath.active.Scan();
        Destroy(gameObject);
    }

    public void uppgradetower(){
        selectedtower.GetComponent<getTowerInfo>().uppgradetower();
    }

    public void cancel(){
        gameObject.SetActive(false);
    }
}
