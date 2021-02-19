using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    AudioSource playerAudioSource;

    [SerializeField] AudioClip playerShoot;
    [SerializeField] AudioClip[] playerDeathSFXs;
    [SerializeField] AudioClip[] playerJumpSFXs;
    [SerializeField] AudioClip[] playerLandSFXs;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();

        SetPlayerAudioVolume();
    }

    public void SetPlayerAudioVolume()
    {
        playerAudioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void PlayPlayerShootSFX()
    {
        if (playerAudioSource.clip != playerShoot)
            playerAudioSource.clip = playerShoot;

        playerAudioSource.Play();
    }
    public void StopPlayerShootSFX()
    {
        if (playerAudioSource.clip == playerShoot)
            playerAudioSource.Stop();
    }
    public void PlayPlayerDeathSFX()
    {
        SetPlayerAudioVolume();
        playerAudioSource.PlayOneShot(playerDeathSFXs[Random.Range(0, playerDeathSFXs.Length)], playerAudioSource.volume);
    }
    public void PlayPlayerJumpSFX()
    {
        SetPlayerAudioVolume();
        playerAudioSource.PlayOneShot(playerJumpSFXs[Random.Range(0, playerJumpSFXs.Length)], playerAudioSource.volume);
    }
    public void PlayPlayerLandSFX()
    {
        SetPlayerAudioVolume();
        playerAudioSource.PlayOneShot(playerLandSFXs[Random.Range(0, playerLandSFXs.Length)], playerAudioSource.volume * .1f);
    }
}
