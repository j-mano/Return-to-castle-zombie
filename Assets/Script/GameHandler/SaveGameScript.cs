using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveGameScript : MonoBehaviour
{
    // This file practaly saves all parameters
    int mapId = 0;

    private static string dataPathGameState = string.Empty;
    private static string dataPathHighscore = string.Empty;

    int towersavestate = 100;

    [System.Serializable]
    private class GameStateData{
        public bool ispausd;
        public int currentvawelevel = 0, mapindex, currencyBrains = 0, currencySeeds = 0;

        // The time to the the game start to spawn enemies.
        public float timetostart;

        // Max amount of towers in game is currently set to 100 towers. if change is necesery, Please edit towersavestate.
        public string[] Towers      = new string[101];
        public float[] Towersposx   = new float[101], Towersposy = new float[101];
        public int wavespasssed     = 0;
    }

    GameStateData gameStateData;
    GameObject GameHandler;

    [Serializable]
    private class GameHighScoreData{
        public int[] currentvaweLevel = new int[10], mapIndex = new int[10], currencyBrains = new int[10], currencySeeds = new int[10], killedEnemies = new int[10], wavespassed = new int[10];
        public string[] map = new String[10], user = new String[10];
    }

    GameHighScoreData highScoreData;
    void Start()
    {
        sessionload();
    }

    void getEconomy()
    {
        gameStateData.currencyBrains = GameHandler.GetComponent<Economy>().getbrains();
        gameStateData.currencySeeds  = GameHandler.GetComponent<Economy>().getseeds();
    }

    void seteconomy(){
        Debug.Log("mängden brains: " + gameStateData.currencyBrains);

        GameHandler.gameObject.GetComponent<Economy>().setBrains(gameStateData.currencyBrains);
        GameHandler.gameObject.GetComponent<Economy>().setSeeds(gameStateData.currencySeeds);
    }

    void findTowerData()
    {
        GameObject[] Towerss;
        Towerss = GameObject.FindGameObjectsWithTag("Tower");

        int i = 0;

        foreach (var tower in Towerss){
            tower.name = tower.name.Replace("(Clone)","").Trim();

            if(i > towersavestate){
                // stopping the foraeachblock here when mamimum saveslots is reacht
                Debug.Log("max limit of towers reachd");
                return;
            }

            gameStateData.Towers[i]     = tower.name;
            gameStateData.Towersposx[i] = tower.transform.position.x;
            gameStateData.Towersposy[i] = tower.transform.position.y;
            i++;
        }
    }

    void placeLoadedTowers()
    {
        // This metod is taking loaded towers in the gameStateData matching it to the rigt tower and initate / placing them.
        // If no match is made is it loading the default tower. Wich are watchtower.
        // Max values is of loaded gameStateData.Towers is currently 101/standing in the class itself at the top.

        // Setting up defualt tower for the placment
        GameObject towerObject = GameHandler.GetComponent<prefabTowersManager>().getWatchTower();

        int i = 0;
        foreach (String tower in gameStateData.Towers){
            if(tower == null || tower == "" || tower == " "){
                GameHandler.GetComponent<towersInScen>().findTowers();
                return;
            }
            towerObject = GameHandler.GetComponent<prefabTowersManager>().getWatchTower();

            foreach (GameObject towerclass in GameHandler.GetComponent<prefabTowersManager>().alltoweArray()){
                if(towerclass.name == tower){
                    towerObject = towerclass;
                }
            }
            towerObject.GetComponent<getTowerInfo>().setaiaktiv(true);
            towerObject.GetComponent<Collider2D>().enabled = true;
            towerObject.tag = "Tower";

            var temp = Instantiate(towerObject, new Vector2(gameStateData.Towersposx[i], gameStateData.Towersposy[i]), transform.rotation);
            i++;
        }
    }

    bool checkpreferensesiscreated(){
        // checking tha the games settings is saved and exist
        bool Exists = false;

        if(PlayerPrefs.HasKey("Exists"))
            Exists = true;

        Debug.Log("Settings exits: " + Exists);
        return Exists;
    }

    void sessionload()
    {
        // Finding the GameHandler and eeconomy of the game session
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        if (!Directory.Exists("savefiles"))
            Directory.CreateDirectory("savefiles");

        dataPathGameState = "savefiles/Statesavefile.json";
        dataPathHighscore = "savefiles/Highscore.json";

        // Session object that are being saved and loaded from file
        gameStateData       = new GameStateData();
        highScoreData       = new GameHighScoreData();

        loadingsavefile();

        // start time. do not use before loading in that from file(comand above)
        float starttime = gameStateData.timetostart;
        InvokeRepeating("levelsetter", starttime + 100, 100f);
    }

    void loadingsavefile(){
        if(checkpreferensesiscreated()){
            mapId = PlayerPrefs.GetInt("mapIndex");
            try{
                if (System.IO.File.Exists(dataPathGameState)){
                    loadsavestate();

                    if(gameStateData.mapindex != mapId){
                        loaddefaultvalues();
                        Debug.Log("Savefiles mapid and current map do not match. Loading defult values");
                    }
                    else{
                        Debug.Log("Data loaded and placing towers");
                        seteconomy();
                        placeLoadedTowers();
                    }
                }
                else{
                    loaddefaultvalues();
                    Debug.Log("No savefile exist. Loading defult values");
                }
            }
            catch (Exception e){
                Debug.Log("Failed to load from file. Reverting to default values." + e);
                loaddefaultvalues();
            }
        }
        else
            playerPrefabDefaultValues();
    }

    public void playerPrefabDefaultValues()
    {
        // Sets so the player know if settings is set prevosly and setting difficulty to avarage. Thats the dificulty set for moast players.
        PlayerPrefs.SetString("Exists", "True");
        PlayerPrefs.SetInt("DificultyInt", 1);
        PlayerPrefs.SetString("Dificulty", "Avarage");

        PlayerPrefs.SetInt("mapIndex", 1);

        // Audio settings
        PlayerPrefs.SetFloat("masterAudio", 1);
        PlayerPrefs.SetFloat("musicAudio", 1);
        PlayerPrefs.SetFloat("sfxAudio", 1);
        
        PlayerPrefs.SetInt("audioonof", 1);

        // This is for setting the default map of the game.
        gameObject.GetComponent<mapCreation>().setdefultmap();

        // manualy force the game engiene to save it directly instead of save it at aplication close.
        PlayerPrefs.Save();
    }

    void loaddefaultvalues()
    {
        gameStateData.wavespasssed      = 0;
        gameStateData.ispausd           = false;
        gameStateData.currentvawelevel  = 1;
        gameStateData.mapindex          = mapId;

        for(int i = 0; i < towersavestate; i++){
            gameStateData.Towers[i] = "";
            gameStateData.Towersposx[i] = 0;
            gameStateData.Towersposy[i] = 0;
        }

        // Timetostart is the time to when the spawner and game starts
        // This is to make it easier for the the player of the game.
        gameStateData.timetostart       = 10f;
        savestate();
    }

    void paus_Update()
    {
        bool paused = GameHandler.GetComponent<PauseManager>().getIfPaus();
        gameStateData.ispausd = paused;
    }

    public int getCurrentLevel()
    {
        return gameStateData.currentvawelevel;
    }

    public void setCurrentLevel(int _inputLevel)
    {
        gameStateData.currentvawelevel = _inputLevel;
    }

    // This function is called when the state of the current game.
    public void savestate()
    {
        String mapnamee   = PlayerPrefs.GetString("mapName");
        paus_Update();

        if(mapnamee.Contains("Test")){
            Debug.Log("save function is called but the map is a test map");
            Debug.Log(mapnamee);
        }
        else{
            getEconomy();
            findTowerData();

            string json = JsonUtility.ToJson(gameStateData);
            
            try{
                File.WriteAllText(dataPathGameState, json);

                Debug.Log("Data saved");
            }
            catch{
                Debug.Log("failed to save the currentstate.");
            }
        }
    }

    public void loadsavestate()
    {
        Debug.Log("loading save");

        string json   = File.ReadAllText(dataPathGameState);
        gameStateData = JsonUtility.FromJson<GameStateData>(json);
    }

    // currently the same as saving the state. todo: create own dataset for the higscore file.
    public void highscoresave()
    {
        String mapnamee   = PlayerPrefs.GetString("mapName");
        if(mapnamee.Contains("Test")){
            Debug.Log("highscoresave function is called but the map is a test map");
        }
        else{
            LoadInfile();
            addcurrentplayer();
            savetofile();
            savelasthighscoretoplayerpref();
        }
    }

    void savelasthighscoretoplayerpref(){
        // This just saves the last highscore on this computer in playerpreferenses.
        // This is used for diferent scens in this game and to send email.
        // This is slitly different from the jason file due to this is just 1 player that playd this last time instead of saving 10 of them that are rankt.

        PlayerPrefs.SetInt("HighscoreWavepassed",gameStateData.wavespasssed);
        PlayerPrefs.SetInt("HighscoreCurrentLVL", getCurrentLevel());
        PlayerPrefs.SetString("HigscoreMapname", PlayerPrefs.GetString("mapName"));
    }

    void addcurrentplayer(){
        int i = 0;
        foreach (String player in highScoreData.user){
            if(player == ""){
                feedplayer(i);
                return;
            }

            if(gameStateData.wavespasssed > highScoreData.wavespassed[i]){
                if(i == 10)
                    feedplayer(i);
                else{
                    movescoredown(i);
                    feedplayer(i);
                }
                return;
            }
            i++;
        }
    }

    void movescoredown(int pos){
        for (int i = (pos + 1); i <= 10; i++) 
        {
            highScoreData.user[i]              = highScoreData.user[i - 1];
            highScoreData.map[i]               = highScoreData.map[i - 1];

            highScoreData.mapIndex[i]          = PlayerPrefs.GetInt("mapIndex");
            highScoreData.currentvaweLevel[i]  = getCurrentLevel();
            highScoreData.wavespassed[i]       = gameStateData.wavespasssed;
        }
    }

    void feedplayer(int pos){
        highScoreData.user[pos]              = "Default user";
        highScoreData.map[pos]               = PlayerPrefs.GetString("mapName");

        highScoreData.mapIndex[pos]          = PlayerPrefs.GetInt("mapIndex");
        highScoreData.currentvaweLevel[pos]  = getCurrentLevel();
        highScoreData.wavespassed[pos]       = gameStateData.wavespasssed;
    }

    void savetofile(){
        if (!Directory.Exists("savefiles"))
            Directory.CreateDirectory("savefiles");

        string json = JsonUtility.ToJson(highScoreData);

        try{
            File.Delete (dataPathHighscore);
            File.WriteAllText(dataPathHighscore, json);

            Debug.Log("Highscore saved");
        }
        catch{
            Debug.Log("failed to save highscore.");
        }
    }

    void LoadInfile(){
        Debug.Log("Loading Higscore");

        try{
            string json   = File.ReadAllText(dataPathHighscore);
            highScoreData = JsonUtility.FromJson<GameHighScoreData>(json);
        }
        catch{
            Debug.Log("error loading higscore");
        }
    }
}
