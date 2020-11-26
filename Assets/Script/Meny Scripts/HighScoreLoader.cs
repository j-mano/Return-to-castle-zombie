using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class HighScoreLoader : MonoBehaviour
{   
    // Loading highscore in the higscore meny. Loading in top 4 of 10 highscores

    [Serializable]
    private class GameHighScoreData{
        // 10 players is saved in array.
        public int[] currentvaweLevel = new int[10], mapIndex = new int[10], currencyBrains = new int[10], currencySeeds = new int[10], killedEnemies = new int[10], wavespassed = new int[10];
        public string[] map = new String[10], user = new String[10];
    }

    GameHighScoreData highScoreData;

    public Text Player1, Player2, Player3, Player4;

    // Start is called before the first frame update
    void Start()
    {
        LoadInfile();
    }

    void LoadInfile(){
        Debug.Log("Loading Higscore");

        try{
            string json   = File.ReadAllText("savefiles/Highscore.json");
            highScoreData = JsonUtility.FromJson<GameHighScoreData>(json);
            printout();
        }
        catch{
            Debug.Log("error loading higscore");
            hidprintout();
        }
    }

    void printout(){
        Player1.text = ("Player: " + highScoreData.user[0] + ", Map: " + highScoreData.map[0] + ", wave: " + highScoreData.wavespassed[0]);
        Player2.text = ("Player: " + highScoreData.user[1] + ", Map: " + highScoreData.map[1] + ", wave: " + highScoreData.wavespassed[1]);
        Player3.text = ("Player: " + highScoreData.user[2] + ", Map: " + highScoreData.map[2] + ", wave: " + highScoreData.wavespassed[2]);
        Player4.text = ("Player: " + highScoreData.user[3] + ", Map: " + highScoreData.map[3] + ", wave: " + highScoreData.wavespassed[3]);
    }

    void hidprintout(){
        Player1.text = ("no higscores found");
        Player2.text = ("");
        Player3.text = ("");
        Player4.text = ("");
    }
}
