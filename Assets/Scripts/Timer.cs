using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
<<<<<<< Updated upstream
    private PlayerController playerController;
=======
>>>>>>> Stashed changes
    private float timeDuration = 1f * 60f;
    private float timer;
    private float flashTimer;
    private float flashLength = 1f;
    private float flasher;
    private float flashDuration = 5f;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
<<<<<<< Updated upstream
    [SerializeField] private TextMeshProUGUI gameOverText;
=======

    private float flashTimer;
    private float flashDuration = 1f;
>>>>>>> Stashed changes

    void Start()
    {
        ResetTimer();
        gameOverText.enabled = false;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(timer > 0) {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        } 
        else Flash();

        if(flasher < 0) SceneManager.LoadScene(0);
    }

    private void ResetTimer() {
        timer = timeDuration;
    }
    private void ResetFlasher() {
        flasher = flashDuration;
    }
    private void UpdateTimerDisplay(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00} {1:00}", minutes, seconds);

        //firstMinute.text = currentTime[0].ToString();
        //secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[3].ToString();
        secondSecond.text = currentTime[4].ToString();
    }

    private void Flash() {
        if(timer != 0) {
            playerController.moveSpeed = 0;
            playerController.jumpForce = 0;
            timer = 0;
            UpdateTimerDisplay(timer);
<<<<<<< Updated upstream
            ResetFlasher();
=======
        }

        if(flashTimer <= 0) {
            flashTimer = flashDuration;
        } else if (flashTimer >= flashDuration / 2) {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        } else {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
>>>>>>> Stashed changes
        }
        
        if (flashTimer <= 0)
        {
            flashTimer = flashLength;
        }
        else if (flashTimer >= flashLength / 2)
        {
            flasher -= Time.deltaTime;
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            flasher -= Time.deltaTime;
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }        
    }

    private void SetTextDisplay(bool enabled) {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
        gameOverText.enabled = enabled;
    }

    private void SetTextDisplay(bool enabled) {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}
