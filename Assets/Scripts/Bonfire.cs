using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public Transform smoke;
    private bool isImmune;
    private bool isTimerRunning;
    private float timeDuration = 1.5f;
    private float timer;
    private Collider blinkGameObject;
    
    void Start () {
        ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;

        isImmune = false;
        isTimerRunning = false;
        timer = timeDuration;
    }

    void Update() {
        if( isTimerRunning == true)
        {
            if(timer > 0) 
            {
                timer -= Time.deltaTime;
            } 
            else
            {
                blinkGameObject.GetComponent<BlinkGameObject>().StopBlinkGameObject();
                isImmune = false;
                isTimerRunning = false;
                ResetTimer();
            }
        }
    }

    private void ResetTimer() {
        timer = timeDuration;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            blinkGameObject = other;
            if (isTimerRunning == false)
            {
                if (timer > 0 && isImmune == false)
                {
                    ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
                    var em = ps.emission;
                    em.enabled = true;
                    StartCoroutine(stopSmoke());

                    isImmune = true;
                    isTimerRunning = true;
                    blinkGameObject.GetComponent<AudioPlayer>().PlayAudio();
                    blinkGameObject.GetComponent<PlayerController>().SubtractHealth(1);
                    blinkGameObject.GetComponent<BlinkGameObject>().CallStartBlinkGameObject();
                }
            }                
        }
    }
    
    IEnumerator stopSmoke() {
        yield return new WaitForSeconds(.2f);
        ParticleSystem ps = smoke.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;
    }
}
