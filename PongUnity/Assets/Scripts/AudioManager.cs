using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip soundClip; // Reference to your audio clip
    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.loop = true; // Set to loop the audio
    }

    private void Update()
    {
        // Check if the button is held down
        if (Input.GetButton("Fire1") && RaycastGun.Instance.isFiringLaser == true)
        {
            if (!isPlaying)
            {
                // Play the sound if it's not already playing
                audioSource.Play();
                isPlaying = true;
            }
        }
        else if (Input.GetButtonUp("Fire1") || RaycastGun.Instance.isFiringLaser == false)
        {
            if (isPlaying)
            {
                // Stop the sound if the button is released
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
