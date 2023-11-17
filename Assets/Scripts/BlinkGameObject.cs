using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameObject : MonoBehaviour
{
    public GameObject targetBlinkObject;
    public float blinkRepeatTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeStateOfGameObject", 0f , blinkRepeatTime);
    }

    void ChangeStateOfGameObject()
    {
        targetBlinkObject.SetActive(!targetBlinkObject.activeInHierarchy);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
