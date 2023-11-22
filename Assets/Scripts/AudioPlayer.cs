using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;

        // Check if AudioSource is present
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
            return;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         PlayAudio();
    //     }
        
    // }

    public void PlayAudio()
    {
        if (enabled && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
