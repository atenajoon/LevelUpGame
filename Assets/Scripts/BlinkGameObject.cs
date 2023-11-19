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
        if(targetBlinkObject.transform.localScale == new Vector3(1, 1, 1)) {
            targetBlinkObject.transform.localScale = new Vector3(0, 0, 0);
        } else targetBlinkObject.transform.localScale = new Vector3(1, 1, 1);
    }
    public void StopBlinkGameObject()
    {
        CancelInvoke();
        targetBlinkObject.SetActive(true);
    }
}
