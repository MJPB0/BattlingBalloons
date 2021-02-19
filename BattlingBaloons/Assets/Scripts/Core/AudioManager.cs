using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource mainAudioSource;

    [SerializeField] AudioClip[] menuClickSFX;
    [SerializeField] AudioClip[] particleCollideSFX;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        mainAudioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuClick()
    {
        mainAudioSource.PlayOneShot(menuClickSFX[Random.Range(0, menuClickSFX.Length)], mainAudioSource.volume * .5f);
    }
    public void PlayParticleColliding()
    {
        mainAudioSource.PlayOneShot(particleCollideSFX[Random.Range(0, particleCollideSFX.Length)], .008f);
    }

    public void SetVolumes(float value)
    {
        mainAudioSource.volume = value;
    }
}
