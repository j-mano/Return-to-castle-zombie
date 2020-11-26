using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getTowerInfo : MonoBehaviour
{
    /*
        This file is taking care if all tower instances and their information like stats if its dead and if its been clickt. one for each instnce. 
        The stats is taken care for each towers individual stat script that acces the set functions in this file to set stats for each instans of the tower.
    */

    private int currenthelt = 0, totalhelt = 0;
    private GameObject preLoadedCanvas, preLoadedHealhtbar, initatedCanvas, initatedHealthbar, GameHandler;
    bool selected = false;

    // Menyobject is supposed to disable things like heahtbar / upgrade meny
    public bool Menyobject = false;
    string type = "Normal";

    void Start()
    {
        Load();
    }

    void Update()
    {
        if (currenthelt <= 0)
            Towerdead();
        else
            updatehealth();
    }

    // Alot of get and set metod to set alot of values. this values is supposed to load and everything related to the tower
    public string getType(){
        return type;
    }

    public void setType(string _inputType){
        type = _inputType;
    }

    public void setcurrenthelt(int inputcurrenthelt){
        currenthelt = inputcurrenthelt;
    }

    public void settotalhelt(int inputtotalhelt){
        totalhelt = inputtotalhelt;
    }

    public int gettotalhelt(){
        return totalhelt;
    }

    public void substracthelht(int damageontower){
        currenthelt = currenthelt - damageontower;
    }

    public int getcurrenthelt(){
        return currenthelt;
    }

    private int towercost = 0;

    public int getTowercost(){
        return towercost;
    }

    public void setTowercost(int inputtowercost){
        towercost = inputtowercost;
    }

    private int towercostseeds = 0;

    public void setTowercostseeds(int inputtowercost){
        towercostseeds = inputtowercost;
    }

    public int getTowercostseeds(){
        return towercostseeds;
    }

    public bool aiaktiv = true;

    public bool getaiaktiv(){
        return aiaktiv;
    }

    public void setaiaktiv(bool setaktivinput){
        aiaktiv = setaktivinput;
    }

    private int towerrange;

    public int gettowerrange(){
        return towerrange;
    }

    public void settowerrange(int inputsettowerrange){
        towerrange = inputsettowerrange;
    }

    private int towerfirerate;

    public void setTowerFireRate(int inputsettowerfirerate){
        towerfirerate = inputsettowerfirerate;
    }

    public int getTowerFireRate(){
        return towerfirerate;
    }

    private int damage = 5;

    public void setdamage(int damageinput){
        damage = damageinput;
    }

    public int getdamage(){
        return damage;
    }

    private int upgradelvl = 0;
    public void uppgradetower(){
        Debug.Log("Tower upgraded");

        // All towers get extra damage by the upgrade. Upgradelvl is planed for individual tower for specifik atrinuted.
        upgradelvl  = upgradelvl + 1;
        damage      = damage + 4;
    }

    public int getupgradelvl(){
        // Upgradelvl is planed for individual tower for specifik atrinuted.
        return upgradelvl;
    }

    void Load(){
        // Loads in Uppgrade / Destroy meny and healhtbar on each instans of the tower and hides it directly
        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        if(Menyobject == false){
            preLoadedCanvas     = Resources.Load ("Prefab/ui/TowerPopupmeny") as GameObject;
            preLoadedHealhtbar  = Resources.Load ("Prefab/ui/Healthbar")      as GameObject;

            if(preLoadedCanvas == null || preLoadedHealhtbar == null){
                Debug.Log("error loading -gettowerinfo");
            }

            initatedCanvas    = (GameObject)Instantiate(preLoadedCanvas);
            initatedHealthbar = (GameObject)Instantiate(preLoadedHealhtbar);

            initatedCanvas.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2);
            initatedHealthbar.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2);

            initatedCanvas.SetActive(false);
            initatedHealthbar.SetActive(false);

            initatedCanvas.GetComponent<popupscript>().setgameobject(gameObject);
        }
    }

    void updatehealth(){
        // Controlling that health values is set to a realistic value and disable the healthbar if not.
        if(totalhelt > 0 && currenthelt >= 0 && currenthelt <= totalhelt && Menyobject == false){
            initatedHealthbar.GetComponent<guiHealthUpdater>().healthupdaate(currenthelt, totalhelt);

            if(currenthelt <= totalhelt && initatedCanvas.activeSelf)
                initatedHealthbar.SetActive(true);
            else
                initatedHealthbar.SetActive(false);
        }
        else if(Menyobject == false){
            initatedHealthbar.SetActive(false);
            if(gameObject.tag != "UI")
                Debug.Log("somthing wrongfyly set up by the towers health. " + gameObject.name);
        }
        else{
            if(gameObject.tag != "UI")
                    Debug.Log("somthing wrongfyly set up by the towers health. " + gameObject.name);
        }
    }

    void OnMouseUpAsButton() {
        // Loads in grid object thats keep some controlls and controlls for placing towers.

        // Checks if any tower is alredy selected and decide to show upgrade destroy / meny. 
        if(GameHandler.GetComponent<towerPlcement>().getselectetower() == null){
            if(selected == false){
                selected = true;
                initatedCanvas.SetActive(true);
            }
            else{
                selected = false;
                initatedCanvas.SetActive(false);
            }
        }
    }

    void Towerdead(){
        // Shoud only contain object.destroy. Write code in OnDestroy() if you need to add anything.
        Object.Destroy(this.gameObject);
    }

    void OnDestroy()
     {
        try{
            Object.Destroy(initatedCanvas);
            Object.Destroy(initatedHealthbar);

            GameHandler.GetComponent<towerPlcement>().settowerrecentlydestroyd(true);
        }
        catch{
            Debug.Log("Error, Faild to remove tower meny panel in an safe manner." + gameObject);
        }
     }
}
