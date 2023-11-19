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
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        flashCoinsText.transform.localScale = new Vector3(0, 0, 0);
        coinsFlashOn = false;
    }
    void Update() {
        leftCoins = playerController.coins;
        flashCoinsText.text = "Coins: " + leftCoins;
        
        if (coinsFlashOn == true) {
            Flash();
            timer += Time.deltaTime;

            if (timer >= flashInterval) {
                coinsFlashOn = false;
                flashCoinsText.transform.localScale = new Vector3(0, 0, 0);
                timer = 0.0f;
            }
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            if (leftCoins == 0) // if all coins are collected load the next scene
            {
                LoadNextScene();
            }
            else // if not, flash the coins' text
            {
                coinsFlashOn = true;
                
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

            flashCoinsText.transform.localScale = new Vector3(0,0,0);
        }
        else
        {
            flasher -= Time.deltaTime;
            flashCoins -= Time.deltaTime;

            flashCoinsText.transform.localScale = new Vector3(1, 1, 1);
        }       
    }
}
