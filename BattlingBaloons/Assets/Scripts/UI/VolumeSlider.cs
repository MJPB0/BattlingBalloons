using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;

    private void Start()
    {
        _volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume()
    {
        PlayerPrefsController.SetMasterVolume(_volumeSlider.value);

        AudioManager.Instance.SetVolumes(PlayerPrefsController.GetMasterVolume());
    }
}
