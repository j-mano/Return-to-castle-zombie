using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchimentActivate : MonoBehaviour
{
    public Image startgame, mechagnome, tower, winagame;
    int startgameAch, mechagnomeAch, towerAch, winagameAch;

    void Start()
    {
        grayallout();
        loadAchimentsFromPlayerPrefabs();
        printoutachiments();
    }

    void grayallout()
    {
        startgame.GetComponent<Image>().color   = new Color32(255,255,225,150);
        mechagnome.GetComponent<Image>().color  = new Color32(255,255,225,150);
        tower.GetComponent<Image>().color       = new Color32(255,255,225,150);
        winagame.GetComponent<Image>().color    = new Color32(255,255,225,150);
    }

    void loadAchimentsFromPlayerPrefabs()
    {
        try{
            startgameAch   = PlayerPrefs.GetInt("HasStartedAnGame");
            mechagnomeAch  = PlayerPrefs.GetInt("HasKilledMechagnome");
            towerAch       = PlayerPrefs.GetInt("Hasplacedalltowers");
            winagameAch    = PlayerPrefs.GetInt("HawWonGame");
        }
        catch{
            Debug.Log("no achiments found");
        }
    }

    void printoutachiments()
    {
        if(startgameAch >= 1)
            startgame.GetComponent<Image>().color   = new Color32(255,255,225,255);
            
        if(mechagnomeAch >= 1)
            mechagnome.GetComponent<Image>().color  = new Color32(255,255,225,255);

        if(towerAch >= 1)
            tower.GetComponent<Image>().color       = new Color32(255,255,225,255);

        if(winagameAch >= 1)
            winagame.GetComponent<Image>().color    = new Color32(255,255,225,255);
    }
}
