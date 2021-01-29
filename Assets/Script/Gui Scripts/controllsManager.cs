using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class controllsManager : MonoBehaviour
{
    /*
        This script i managing the keys shoud be assignd to witch standard funktion.
        Added late in development. might not be fuly utilites everywhere get. TODO: update game to utilise these controls
    */
    KeyCode infopanelMenytBtn, mainMeny, paus, paus2;
    KeyCode hotkey0, hotkey1, hotkey2, hotkey3, hotkey4, hotkey5, hotkey6, hotkey7, hotkey8, hotkey9;
    KeyCode autoHealth, incSpawn, decSpawn;

    void Start()
    {
        controlsDef();
    }

    void controlsDef(){
        Task t1 = Task.Run( () => {
            standardControlls();
            gameplayControlls();
        });

        Task t2 = Task.Run( () => {
            hotKeys();
            testMapKeys();
        });

        t1.Wait();
        t2.Wait();
    }

    void standardControlls(){
        infopanelMenytBtn = KeyCode.Tab;
        mainMeny          = KeyCode.Escape;
    }

    void gameplayControlls(){
        paus              = KeyCode.Pause;
        paus2             = KeyCode.P;
    }

    void hotKeys(){
        hotkey0           = KeyCode.Alpha0;
        hotkey1           = KeyCode.Alpha1;
        hotkey2           = KeyCode.Alpha2;
        hotkey3           = KeyCode.Alpha3;
        hotkey4           = KeyCode.Alpha4;
        hotkey5           = KeyCode.Alpha5;
        hotkey6           = KeyCode.Alpha6;
        hotkey7           = KeyCode.Alpha7;
        hotkey8           = KeyCode.Alpha8;
        hotkey9           = KeyCode.Alpha9;
    }

    void testMapKeys(){
        autoHealth       = KeyCode.A;
        incSpawn         = KeyCode.W;
        decSpawn         = KeyCode.D;
    }

    public KeyCode getMainMenytBtn(){
        return mainMeny;
    }

    public KeyCode getinfopanelMenytBtn(){
        return infopanelMenytBtn;
    }

    public KeyCode getIncSpawnBtn(){
        return incSpawn;
    }

    public KeyCode getDecSpawnBtn(){
        return decSpawn;
    }

    public KeyCode getautoHealthBtn(){
        return autoHealth;
    }

    public KeyCode getPauseBtn(){
        return paus;
    }

    public KeyCode getPauseBtn2(){
        return paus2;
    }

    public KeyCode getHotKeyBtn0(){
        return hotkey0;
    }

    public void setHotKeyBtn0(KeyCode inputkey){
        hotkey0 = inputkey;
    }

    public KeyCode getHotKeyBtn1(){
        return hotkey1;
    }

    public void setHotKeyBtn1(KeyCode inputkey){
        hotkey1 = inputkey;
    }

    public KeyCode getHotKeyBtn2(){
        return hotkey2;
    }

    public void setHotKeyBtn2(KeyCode inputkey){
        hotkey2 = inputkey;
    }

    public KeyCode getHotKeyBtn3(){
        return hotkey3;
    }

    public void setHotKeyBtn3(KeyCode inputkey){
        hotkey3 = inputkey;
    }

    public KeyCode getHotKeyBtn4(){
        return hotkey4;
    }

    public void setHotKeyBtn4(KeyCode inputkey){
        hotkey4 = inputkey;
    }

    public KeyCode getHotKeyBtn5(){
        return hotkey5;
    }

    public void setHotKeyBtn5(KeyCode inputkey){
        hotkey5 = inputkey;
    }

    public KeyCode getHotKeyBtn6(){
        return hotkey6;
    }

    public void setHotKeyBtn6(KeyCode inputkey){
        hotkey6 = inputkey;
    }

    public KeyCode getHotKeyBtn7(){
        return hotkey7;
    }

    public void setHotKeyBtn7(KeyCode inputkey){
        hotkey7 = inputkey;
    }

    public KeyCode getHotKeyBtn8(){
        return hotkey8;
    }

    public void setHotKeyBtn8(KeyCode inputkey){
        hotkey8 = inputkey;
    }

    public KeyCode getHotKeyBtn9(){
        return hotkey9;
    }

    public void setHotKeyBtn9(KeyCode inputkey){
        hotkey9 = inputkey;
    }
}
