using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkGameObject : MonoBehaviour
{
    public GameObject targetBlinkObject;

    // Start is called before the first frame update
    void Start()
    {
        ChangeStateOfGameObject();
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
