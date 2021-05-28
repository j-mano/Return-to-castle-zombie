using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthslider : MonoBehaviour
{
    // handling the healhbar in the top of the gui.
    public Slider slider;
    public Text towertext;

    public GameObject gamehandler, CastleManager;

    int maxamonutoftowers,currentamountoftowers;

    void Update()
    {
        getmaxtowers();
        getcurrentamounttowers();
        PrintMaxTowers();
        Health();
    }

    private async void Health(){
        slider.value = await CastleManager.GetComponent<CastleManager>().getCastleHealthAsync();
    }

    private void getmaxtowers(){
        maxamonutoftowers = gamehandler.GetComponent<towersInScen>().getMaxtowers();
    }

    private void getcurrentamounttowers(){
        currentamountoftowers = gamehandler.GetComponent<towersInScen>().getamountoftowers();
    }

    public void PrintMaxTowers(){
        towertext.text = "Towers: " + currentamountoftowers + "/" + maxamonutoftowers;
    }
}
