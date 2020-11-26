using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake(){
        // All loaded sounds atributes is set in here

        float mastesoundlevel, musicLevel, SFXLevel;
        int audionoff;

        // Try catch is used if the game is run without going to through the meny and setting the defult setting or player never setting it.
        try{
            mastesoundlevel     = PlayerPrefs.GetFloat("masterAudio");
            audionoff           = PlayerPrefs.GetInt("audioonof");
            SFXLevel            = PlayerPrefs.GetFloat("sfxAudio");
            musicLevel          = PlayerPrefs.GetFloat("musicAudio");
        }
        catch{
            mastesoundlevel     = 1f;
            audionoff           = 1;
            SFXLevel            = 1f;
            musicLevel          = 1f;

            Debug.Log("Error failed to load audio settings. Falling back to default volum. - Audiomanager");
        }

        foreach ( Sound s in sounds){
            s.source        = gameObject.AddComponent<AudioSource>();
            s.source.clip   = s.clip;
            s.source.pitch  = s.pitch;  
            s.source.loop   = s.loop;
            s.source.volume = s.volume;

            // Setting the audolevel based on the master audio level in the settings.
            if(audionoff == 1){
                // id 0 = music, id 1 = sfx
                if(s.id == 0)
                    s.source.volume = (s.volume * musicLevel) * mastesoundlevel;
                if(s.id == 1)
                    s.source.volume = (s.volume * SFXLevel) * mastesoundlevel;
            }
            else if(audionoff == 0)
                s.source.volume = 0;
        }

        maintheme();
    }

    void maintheme(){
        // Playing the main sounds of the projects
        Play("MainTheme");
    }

    public void Play (string name){
        // This function is playing selected sound from the list loaded in the awake function in this script.

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null){
            Debug.Log("Error. Null audio value is being loaded. Audio that are tryed to be loaded is: " + name);
            return;
        }

        s.source.Play();
    }
}
