using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameObject : MonoBehaviour
{
    public GameObject targetBlinkObject;
    public float blinkRepeatTime = 1f;
    public float blinkInitialPause = 1f;
    public bool startBlink;

    // Start is called before the first frame update
    void Start()
    {
        startBlink = false;
        // if (startBlink == true) CallChangeStateOfGameObject();
    }
    void CallChangeStateOfGameObject()
    {
        InvokeRepeating("ChangeStateOfGameObject", 0f , blinkRepeatTime);   
    }

    void ChangeStateOfGameObject()
    {
        targetBlinkObject.SetActive(!targetBlinkObject.activeInHierarchy);
    }
    void PauseChangeStateOfGameObject()
    {
        targetBlinkObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (startBlink == true)
        {

            // Debug.Log("Start Blink");
            CallChangeStateOfGameObject();
            startBlink = false;
        }
        else 
        {
            PauseChangeStateOfGameObject();
        }
    }
}
