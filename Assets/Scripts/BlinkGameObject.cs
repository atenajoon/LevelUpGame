using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameObject : MonoBehaviour
{
    public GameObject targetBlinkObject;
    public float blinkRepeatTime = 1f;
    public float blinkInitialPause = 1f;


    public void CallStartBlinkGameObject()
    {
        InvokeRepeating("StartBlinkGameObject", 0f , blinkRepeatTime);   
    }

    void StartBlinkGameObject()
    {
        targetBlinkObject.SetActive(!targetBlinkObject.activeInHierarchy);
    }
    public void StopBlinkGameObject()
    {
        CancelInvoke();
        targetBlinkObject.SetActive(true);
    }
}
