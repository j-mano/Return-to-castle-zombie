using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class audioMeny : MonoBehaviour
{
    GameObject audioTogle;
    GameObject masterAudioVolum;
    GameObject sfxAudioVolum;
    GameObject musicAudioVolum;

    // Start is called before the first frame update
    void Start()
    {
        try{
            // Finding the controlls relevant to the script.
            audioTogle          = GameObject.Find("ToggleAudio");
            masterAudioVolum    = GameObject.Find("MasterVolSlider");
            sfxAudioVolum       = GameObject.Find("MusicVolSlider");
            musicAudioVolum     = GameObject.Find("SFXVolSlider");
        }
        catch{
            Debug.Log("cant access audio controlls");
        }

        filldroppdownboxes();
    }

    void filldroppdownboxes(){
        audiotogle();

        // Updating the slidervolum in the meny.
        masterAudioSliderUpdate();
        SFXSudioSliderUpdate();
        musicSudioSliderUpdate();
    }

    void masterAudioSliderUpdate(){
        masterAudioVolum.GetComponent<Slider>().value   = PlayerPrefs.GetFloat("masterAudio");
    }

    void SFXSudioSliderUpdate(){
        sfxAudioVolum.GetComponent<Slider>().value      = PlayerPrefs.GetFloat("sfxAudio");
    }

    void musicSudioSliderUpdate(){
        musicAudioVolum.GetComponent<Slider>().value    = PlayerPrefs.GetFloat("musicAudio");
    }

    void audiotogle(){
        float audionoff = PlayerPrefs.GetInt("audioonof");

        if(audionoff == 1)
            audioTogle.GetComponent<Toggle>().isOn = true;
        else if(audionoff == 0)
            audioTogle.GetComponent<Toggle>().isOn = false;
    }

    public void setMasterVolum(float volum){
        PlayerPrefs.SetFloat("masterAudio", volum);
        savetofile();
    }

    public void setSFXVolum(float volum){
        PlayerPrefs.SetFloat("sfxAudio", volum);
        savetofile();
    }

    public void setMusicVolum(float volum){
        PlayerPrefs.SetFloat("musicAudio", volum);
        savetofile();
    }

    void savetofile(){
        PlayerPrefs.Save();
    }
}
