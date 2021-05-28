using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endofgameparameter : MonoBehaviour
{
    // Only reason this exist is to check the healh of the castle / game and change sceen if it at 0.
    GameObject healthSlider, GameHandler, castle;
    float helht;

    void Start()
    {
        load();
    }

    void Update()
    {
        healtcheck();
    }

    void load(){
        GameHandler     = GameObject.FindGameObjectWithTag("GameHandler");
        healthSlider    = GameObject.FindGameObjectWithTag("healthSlider");
        castle          = GameObject.FindGameObjectWithTag("castle");
    }

    async void healtcheck(){
        helht = await castle.GetComponent<CastleManager>().getCastleHealthAsync();

        if (helht <= 0)
            gameLost();
    }

    void gameLost(){
        GameHandler.GetComponent<SaveGameScript>().highscoresave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
