using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class towerPlcement : MonoBehaviour
{
    GameObject tower0, tower1, tower2, tower3, tower4, tower5, tower6, hut, chruch, Wall, GameHandler, zombie_on_lily;
    public GameObject hud;
    Vector2 mousePotition;
    Rigidbody2D rb2D;
    GameObject target, currenttarget;

    private string targetname = "Torn";
    bool towerrecentlydestroyd = false;
    float timesincetowerdes = 0;

    // moore than 100 towers will make it hard to play the game. no moore than 100 towers allowd.
    int MaxTower = 100, currenttowers;

    // Must be loaded togheder with the economy handleing files on the castla thats the default at this game.
    void Start()
    {
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        loadTowers();
        gameObject.GetComponent<towersInScen>().setMaxtowers(MaxTower);
    }

    void loadTowers(){
        tower0          = GameHandler.GetComponent<prefabTowersManager>().getBallonTower()     as GameObject;
        tower1          = GameHandler.GetComponent<prefabTowersManager>().getWatchTower()      as GameObject;
        tower2          = GameHandler.GetComponent<prefabTowersManager>().getCanonTower()      as GameObject;
        tower3          = GameHandler.GetComponent<prefabTowersManager>().getTower_Zombie()    as GameObject;
        tower4          = GameHandler.GetComponent<prefabTowersManager>().getTesla_Coil()      as GameObject;
        tower5          = GameHandler.GetComponent<prefabTowersManager>().getTrench()          as GameObject;
        tower6          = GameHandler.GetComponent<prefabTowersManager>().getTreadmil()        as GameObject;
        hut             = GameHandler.GetComponent<prefabTowersManager>().getZombie_Hut()      as GameObject;
        Wall            = GameHandler.GetComponent<prefabTowersManager>().getBlocktower()      as GameObject;
        chruch          = GameHandler.GetComponent<prefabTowersManager>().getChurch()          as GameObject;
        zombie_on_lily  = GameHandler.GetComponent<prefabTowersManager>().getZombie_on_lily()  as GameObject;

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getmousepos();
        mnouseanimation();
        controlls();
    }

    public void setMaxTower(int _input){
        MaxTower = _input;
        gameObject.GetComponent<towersInScen>().setMaxtowers(MaxTower);
    }

    public int getMaxTower(){
        return MaxTower;
    }

    // Public function that send out selected tower. free hand / not selected tower = sending out null.
    public GameObject getselectetower(){
        return target;
    }

    // Gets the cost of the selexted tower.
    private int[] importtowercost(){
        int[] towercost = {0,0};

        if (target == null){
            towercost[0] = 0;
            towercost[1] = 0;
        }
        else{
            towercost[0] = target.GetComponent<getTowerInfo>().getTowercost();
            towercost[1] = target.GetComponent<getTowerInfo>().getTowercostseeds();
        }
        
        return towercost;
    }

    // Get the current amount of brains from the GameHandler
    private int importcurrentcash(){
        int currentcash;
        currentcash = gameObject.GetComponent<Economy>().getbrains();
        return currentcash;
    }

    // Get the current amount of seeds from the GameHandler
    private int importcurrentseeds(){
        int currentcash;
        currentcash = gameObject.GetComponent<Economy>().getseeds();
        return currentcash;
    }

    // This function check the resources that are stored in the GameHandler to what the selected tower cost and gives an value if youy can afford it.
    bool checkifcanaffordCost(){
        bool canAfford   = false;

        int[] towercost  = importtowercost();
        int currentcash  = importcurrentcash();
        int currentseeds = importcurrentseeds();

        if(currentcash >= towercost[0] && currentseeds >= towercost[1]){
            canAfford    = true;
        }
        else{
            Debug.Log("Can't afford building");
        }

        return canAfford;
    }

    // Drains the cost of the selected tower from the GameHandler storage of brains and seeds.
    bool drainCost(){
        bool costhasdraind = false;

        if (checkifcanaffordCost() == true){
            int[] towercost = importtowercost();
            gameObject.GetComponent<Economy>().substractBrains(towercost[0]);
            gameObject.GetComponent<Economy>().substractseeds(towercost[1]);

            costhasdraind = true;
        }
        
        return costhasdraind;
    }

    void getmousepos(){
        mousePotition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Make the copy of the selected tower following the players mouse
    void mnouseanimation(){
        if(target != null){
            if(Input.GetAxis("Mouse X") < 0){
                target.transform.position = mousePotition;
            }
            else if(Input.GetAxis("Mouse X") > 0){
                target.transform.position = mousePotition;
            }
        }
    }

    void controlls(){
        if (Input.GetButtonDown("Fire1")){
            checkMapTowerRules();
        }
    }

    void checkMapTowerRules(){
        RaycastHit2D hit;
        string targettype = "";

        if(target != null)
            targettype = target.GetComponent<getTowerInfo>().getType();

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        // Cheking if somthing is in the way using raycast. Note Guie is not blocking raycasting in anyway and is handled sepratly
        if(hit.collider == null)
        {
            if(!EventSystem.current.IsPointerOverGameObject()){
                if(targettype == "WaterTower"){
                    Debug.Log("Trying to load tower meant for water on land");
                }
                else
                    towerplacementdraincost();
            }
        }
        else{
            if(targettype == "Hower"){
                Debug.Log("placing hower tower");
                towerplacementdraincost();
            }
            else if(targettype == "WaterTower" && hit.collider.name == "Water"){
                Debug.Log("placing watertype tower");
                towerplacementdraincost();
            }
            else
                Debug.Log("Stuff in the way plese selecet other placement. object in the way: " + hit.collider);
        }
    }

    void towerplacementdraincost(){
        currenttowers = GameHandler.GetComponent<towersInScen>().getamountoftowers();

        // check so tower is selected.
            if(target != null){
                if(currenttowers <= MaxTower){
                    if(drainCost())
                        towerplacement();
                    else
                        Debug.Log("cant afford that");
                }
                else
                    Debug.Log("Max amount of towers");
            }
            else
                Debug.Log("no tower selected.");
    }

    // This function is setting the construction meny to aktiv.
    bool anyaktivpopups(){
        bool aktivpopupss           = false;
        GameObject[] popuparray     = GameObject.FindGameObjectsWithTag("popup");

        foreach(GameObject popup in popuparray){
            if(popup.activeSelf)
                aktivpopupss = true;
        }

        return aktivpopupss;
    }
    
    // This function is placing the tower and aktivates the correkt atributes for selected tower and initate a copy of it and deaktivate the atributes again.
    void towerplacement(){
        if(target != null){

            aktivateTower();

            Instantiate(target, target.transform.position, transform.rotation);
            FindObjectOfType<audiomanager>().Play("towerplacementaudio");

            deAktivateTower();

            // Rescan the map for walable space for enemy AI
            AstarPath.active.Scan();
            GetComponent<towersInScen>().findTowers();
            gameObject.GetComponent<towersInScen>().setMaxtowers(MaxTower);
        }
    }

    void aktivateTower(){
        // Set the target tag to untagged. this is to make it envisible for enemy ai and set it to tower wen placed
        target.tag = "Tower";

        // Reenable selected tower
        target.GetComponent<getTowerInfo>().setaiaktiv(true);
        target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            
        try{
            target.GetComponent<Collider2D>().enabled       = true;
        }
        catch{
            // This try catch is for walkable tower. todo: rebuiold function to take this in considirtation.
        }
    }

    void deAktivateTower(){
        // Redisable selected tower
        target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        target.GetComponent<getTowerInfo>().setaiaktiv(false);

        try{
            target.GetComponent<Collider2D>().enabled       = false;
        }
        catch{
            // This try catch is for walkable tower. todo: rebuiold function to take this in considirtation.
        }

        // set the target tag to untagged. this is to make it envisible for enemy ai
        target.tag = "Untagged";
    }

    // This function is setting the selected tower to the game and deaktivates a few funtions of the specifikt selected tower instance.
    public void settargettower(GameObject tower, string namn){
        if(anyaktivpopups() == false && tower != null){
            if(target == null){
                target      = tower;
                targetname  = namn;

                // set the target tag to untagged. this is to make it envisible for enemy ai
                target.tag  = "Untagged";
                target.GetComponent<getTowerInfo>().setaiaktiv(false);
                target      = (GameObject)Instantiate(tower);
                try{
                    target.GetComponent<Collider2D>().enabled = false;
                }
                catch{
                    // This try catch is for walkable tower. todo: rebuiold function to take this in considirtation.
                }
                
            }
            else if(targetname != namn)
            {
                Destroy(target);
                target      = tower;
                targetname  = namn;

                // set the target tag to untagged. this is to make it envisible for enemy ai
                target.tag  = "Untagged";
                target.GetComponent<getTowerInfo>().setaiaktiv(false);
                target      = (GameObject)Instantiate(tower);
                try{
                    target.GetComponent<Collider2D>().enabled = false;
                }
                catch{
                    // This try catch is for walkable tower. todo: rebuiold function to take this in considirtation.
                }
            }
        }
    }

    // Here do we find alot of functions related that are calld upon to select a tower. gui part ueses this to select towers via buttons and hotkeys.
    public void selectedTower0(){
        string namn = "Torn0";

        settargettower(tower0, namn);
    }

    public void selectedTower1(){
        string namn = "Torn1";

        settargettower(tower1, namn);
    }

    public void selectedTower2(){
        string namn = "Torn2";

        settargettower(tower2, namn);
    }

    public void selectedTower3()
    {
        string namn = "Torn3";

        settargettower(tower3, namn);
    }

    public void selectedtsla()
    {
        string namn = "Tesla";

        settargettower(tower4, namn);
    }

    public void selectedTower5()
    {
        string namn = "Torn5";

        settargettower(tower5, namn);
    }

    public void selectedTower6()
    {
        string namn = "Torn6";

        settargettower(tower6, namn);
    }

    public void selectedWall(){
        string namn = "Wall";

        settargettower(Wall, namn);
    }

    public void selectedMedecinhut(){
        string namn = "Medecinhut";

        settargettower(hut, namn);
    }

    public void selectedChruch(){
        string namn = "Chruch";

        settargettower(chruch, namn);
    }

    public void selectedzombieLily(){
        string namn = "zombieLily";

        settargettower(zombie_on_lily, namn);
    }
    // if no tower is selected is the target set to null and mouste be handeld.
    public void targettowernone(){
        Destroy(target);
        target = null;
    }

    public void settowerrecentlydestroyd(bool Input){
        AstarPath.active.Scan();
        towerrecentlydestroyd   = Input;
        timesincetowerdes       = Time.time;

        // Recently = 1 secund and caling a function to set recently to false with delay of 1sek with reapeting functionality thats imedelty canceld
        InvokeRepeating("cleantowerrecentlydestroyd", 1, 0);
    }

    void cleantowerrecentlydestroyd(){
        // Is reapeating but is caandceld imedelty

        towerrecentlydestroyd   = false;
        CancelInvoke();
    }

    public bool gettowerrecentlydestroyd(){
       return towerrecentlydestroyd;
    }

    // Controlls for placing towers by using keypad. Can possibly be used by controller in the future.
    public void controllfunction(string key)
    {
        Vector2 targetpos = target.transform.position;

        if(target != null){
            if (key == "up")
                targetpos.y = targetpos.y + 0.1f;
            else if (key == "down")
                targetpos.y = targetpos.y - 0.1f;
            else if (key == "left")
                targetpos.x = targetpos.x - 0.1f;
            else if (key == "right")
                targetpos.x = targetpos.x + 0.1f;
            else if (key == "place")
                towerplacementdraincost();

            target.transform.position = targetpos;
        }
    }
}
