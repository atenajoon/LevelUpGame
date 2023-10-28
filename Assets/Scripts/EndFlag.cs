using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;
    private int leftCoins;
    private PlayerController playerController;

    private void OnTriggerEnter (Collider other)
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        leftCoins = playerController.coins;
        if(other.CompareTag("Player"))
        {
            if (leftCoins == 0)
            {
                LoadNextScene();
            }
            else
            {
                playerController.message = "You are missing " + leftCoins + " coins to collect!";
            }
        }
    }

    private void LoadNextScene() {
        if(lastLevel == true)
        {
            SceneManager.LoadScene(0); //the first scene in the list, which is usually the "Menu" scene
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
