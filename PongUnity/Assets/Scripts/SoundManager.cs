using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource buttonSelect;
    public List<AudioSource> wormSounds;
    int wormSoundIndex;

    public List<AudioSource> laserHitSounds;
    int laserHitSoundIndex;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayButtonSelectSound()
    { 
        buttonSelect.Play();
    }

    public void PlayWormSound()
    {
        if (wormSoundIndex < wormSounds.Count - 1)
        {
            wormSoundIndex++;
        }
        else
        {
            wormSoundIndex = 0;
        }

        float randPitch;
        randPitch = Random.Range(0.85f, 1.15f);
        wormSounds[wormSoundIndex].pitch = randPitch;
        wormSounds[wormSoundIndex].Play();
    }

    public void PlayLaserHitSound()
    {
        if (laserHitSoundIndex < laserHitSounds.Count - 1)
        {
            laserHitSoundIndex++;
        }
        else
        {
            laserHitSoundIndex = 0;
        }

        float randPitch;
        randPitch = Random.Range(0.85f, 1.15f);
        laserHitSounds[laserHitSoundIndex].pitch = randPitch;
        laserHitSounds[laserHitSoundIndex].Play();
    }
}
