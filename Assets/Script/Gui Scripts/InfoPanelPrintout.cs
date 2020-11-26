using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoPanelPrintout : MonoBehaviour
{
    // This function is printing out info about hardware and gameparameters from the game in the F5 / infomeny
    GameObject GameHandler;
    float helht;

    public Text GpuApi, OS, resolution, Amountofenemies, renderDevice, fpscounter, maplvl;
    public float currentfps;
    private string dificulty;
    private int dificultyid, currentlevel;

    void Start()
    {
        loadPrameters();
        setInfoMenyText();
        debugPrintout();

        GameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        // FPS counter printout. only text of thtat update slower than the actual framerate. this is for get a moore even and moore acurcy in the frameratecounter.
        InvokeRepeating("updatingInfoMenyText",0,1f);
        Application.targetFrameRate = 200;// for testing setting max framerate for the game.
    }

    void Update()
    {
        CalcFps();
        getLvl();
        
        setDifficulty();
    }

    void getLvl(){
        currentlevel = GameHandler.GetComponent<SaveGameScript>().getCurrentLevel();
    }

    void CalcFps(){
        currentfps = (int)(1f / Time.unscaledDeltaTime);
    }

    void setDifficulty(){
        // if the id dosent match upp with id correspondent id so is it correcting it;
        switch (dificultyid)
        {
            case 0:
                if(dificulty != "Easy")
                    changeDifName();
                
                break;
            case 1:
                if(dificulty != "Avarage")
                    changeDifName();
                
                break;
            case 2:
                if(dificulty != "Hard")
                    changeDifName();
                
                break;
            default:
                Debug.Log("Error difficly do not exist" + gameObject);
                break;
        }
    }

    void loadPrameters(){
        dificultyid     = PlayerPrefs.GetInt("DificultyInt");
        dificulty       = PlayerPrefs.GetString("Dificulty");
    }

    void debugPrintout(){
        Debug.Log(SystemInfo.graphicsDeviceType);
        Debug.Log(SystemInfo.graphicsDeviceVersion);
        Debug.Log("Dificulty: " + dificulty + " Id: " + dificultyid);
    }

    void setInfoMenyText()
    {
        // Setting the text for F5 / info meny.
        GpuApi.text             = ("RenderApi: " + SystemInfo.graphicsDeviceVersion);
        resolution.text         = ("Resulution: " + Screen.width.ToString() + " , " + Screen.height.ToString());
        OS.text                 = ("OS: " + SystemInfo.operatingSystem);
        renderDevice.text       = ("Gpu: " + SystemInfo.graphicsDeviceName.ToString());
        Amountofenemies.text    = ("Dificulty: " + dificulty + " Id: " + dificultyid.ToString());
        maplvl.text             = ("Game level: " + currentlevel.ToString());
    }

    // This function just updateing the printout of the fps.
    void updatingInfoMenyText(){
        // Updates 10 times a secund. Being set in start in this script.
        fpscounter.text = ("FPS:" + " " + currentfps);
        maplvl.text     = ("Game level: " + currentlevel.ToString());
    }
    
    void changeDifName(){
        // ID number of the dificulty is the primary way to change the dificulty
        // This pice of code change the name dependfend on the id;
        // The dificulty string is for gui only.
        // this exist on 2 places. here and in settingsmeny in the menyscene.

        string Dificulty = "";

        if (PlayerPrefs.GetInt("Dificulty") == 0){
            Dificulty = "Easy";
        } else if (PlayerPrefs.GetInt("Dificulty") == 1){
            Dificulty = "Avarage";
        } else if (PlayerPrefs.GetInt("Dificulty") >= 2){
            Dificulty = "Hard";
        }

        PlayerPrefs.SetString("Dificulty", Dificulty);

        setInfoMenyText();
    }
}