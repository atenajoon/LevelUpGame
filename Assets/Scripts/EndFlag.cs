using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;
    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(lastLevel == true)
            {
                SceneManager.LoadScene(0); //the first scene in the list, which is usually the "Menu" scene
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
