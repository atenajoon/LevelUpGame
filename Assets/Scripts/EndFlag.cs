using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;
    private int leftCoins;
    private bool coinsFlashOn;
    private PlayerController playerController;
    private float flashCoins;
    private float flashLength = 1f;
    private float flasher;
    private float flashDuration = 2f;
    private float flashInterval = 3f;
    private float timer = 0.0f;
    [SerializeField] private TextMeshProUGUI flashCoinsText;

    void Start() {
        flashCoinsText.enabled = false;
        coinsFlashOn = false;
    }
    void Update() {
        if (coinsFlashOn == true) {
            Flash();
            timer += Time.deltaTime;

            if (timer >= flashInterval) {
                coinsFlashOn = false;
                flashCoinsText.enabled = false;
                timer = 0.0f;
            }
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        leftCoins = playerController.coins;
        if(other.CompareTag("Player"))
        {
            if (leftCoins == 0) // if all coins are collected load the next scene
            {
                LoadNextScene();
            }
            else // if not, flash the coins' text
            {
                coinsFlashOn = true;
                flashCoinsText.text = "Coins: " + leftCoins;
            }
        }
    }

    private void LoadNextScene() {
        if(lastLevel == true)
        {
            SceneManager.LoadScene(1); //the second scene in the list, which is supposed to be the "Win-Menu" scene
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void ResetFlasher() { // sets the flashe's blinking duration
        flasher = flashDuration;
    }

    private void Flash() {
        ResetFlasher();
        
        if (flashCoins <= 0)
        {
            flashCoins = flashLength;
        }
        else if (flashCoins >= flashLength / 2)
        {
            flasher -= Time.deltaTime;
            flashCoins -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flasher -= Time.deltaTime;
            flashCoins -= Time.deltaTime;
            SetTextDisplay(true);
        }       
    }

    private void SetTextDisplay(bool enabled) {
        flashCoinsText.enabled = enabled;
    }


}
