using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class UsageScript : MonoBehaviour
{
    // This document printing out the performance to the gui and compliments the gampleyparameters
    // The code in this is building on .net 4.0 while the rest om the game is building on 2.0.
    // Remove this script if target system dosent support certend dependencis or that the platform doesent support hardware readings.
    // This is only loaded on testmaps
    // Some computers have problems with showing cpu usage and report 100% all the time. Reason unkonwn at the moment.

    PerformanceCounter cpuCounter;
    GameObject[] enemies;
    GameObject map, GamHandler;
    public Text computerloadTxt;

    GameObject gamehandler;

    void Start()
    {
        load();
        Invoke("delaydload", 0.4f);
    }

    void load(){
        gamehandler         = GameObject.FindGameObjectWithTag("GameHandler");

        cpuCounter = new PerformanceCounter();

        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
    }

    // Make sure that the map is loaded
    void delaydload(){
        map = GameObject.FindGameObjectWithTag("Grid");

        if(map.name.Contains("Test")){
            InvokeRepeating("printOutCpuUsage",0,2f);
        }
    }

    void printOutCpuUsage(){
        // cpu printout is the total load of the cpu. Thats mean load from all aplications
        //enemies = GameObject.FindGameObjectsWithTag("enemyTag");

        enemies = gamehandler.GetComponent<enemiesInScene>().getenemiesarray();

        computerloadTxt.text = ("CPU usage:" + " " + getCurrentCpuUsage() + "\n" + "Amount of enemies:" + " " + enemies.Length);
    }

    public string getCurrentCpuUsage(){
        return cpuCounter.NextValue()+"%";
    }
}
