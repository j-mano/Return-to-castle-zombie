using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiHealthUpdater : MonoBehaviour
{
    // handling the healhbar in the top of the gui.
    public GameObject healthbar, maxhealht;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.transform.localScale = maxhealht.transform.localScale;
    }

    // Putting in total heahlt of the object and current health;
    public void healthupdaate(float objectcurrenthealth, float objecttotalhealth){
        // % of the totalhealth of the objetct
        float procent;

        if(objectcurrenthealth != 0)
            procent = objectcurrenthealth / objecttotalhealth;
        else
            procent = 0;
            
        // Setting the size of the healhtpanel and letting the bigger one be. symbolising the healht
        healthbar.transform.localScale = new Vector3 (procent, procent, procent);
    }
}
