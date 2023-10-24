using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeDuration = 1f * 60f;
    private float timer;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;

    private float flashTimer;
    private float flashDuration = 1f;

    void Start()
    {
        ResetTimer();
    }


    void Update()
    {
        if(timer > 0) {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        } else {
            Flash();
        }
    }

    private void ResetTimer() {
        timer = timeDuration;
    }
    private void UpdateTimerDisplay(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00} {1:00}", minutes, seconds);

        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[3].ToString();
        secondSecond.text = currentTime[4].ToString();
    }

    private void Flash() {
        if(timer != 0) {
            timer = 0;
            UpdateTimerDisplay(timer);
        }

        if(flashTimer <= 0) {
            flashTimer = flashDuration;
        } else if (flashTimer >= flashDuration / 2) {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        } else {
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
    }
}
