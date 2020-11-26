using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour
{
    // This document is storing the economy in the game and update gui.
    public int currentAmountZombieBrains, currentAmountSeeds;

    void Start()
    {
        currentAmountZombieBrains = 10;
        currentAmountSeeds = 0;
    }

    public void addbrains(int brainsinput){
        currentAmountZombieBrains = currentAmountZombieBrains + brainsinput;
    }

    public int getbrains(){
        return currentAmountZombieBrains;
    }

    public int getseeds(){
        return currentAmountSeeds;
    }

    public void substractBrains(int _cost){
        currentAmountZombieBrains = currentAmountZombieBrains - _cost;
    }

    public void setBrains(int _brainInput){
        currentAmountZombieBrains = _brainInput;
    }

    public void addseeds(int _seedsInput){
        currentAmountSeeds = currentAmountSeeds + _seedsInput;
    }

    public void substractseeds(int _cost){
        currentAmountSeeds = currentAmountSeeds - _cost;
    }

    public void setSeeds(int _seedsInput){
        currentAmountSeeds = _seedsInput;
    }
}
