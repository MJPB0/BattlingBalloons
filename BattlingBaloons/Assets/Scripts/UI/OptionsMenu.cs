using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Button _keybindsButton;
    [SerializeField] Button _returnButton;
    [SerializeField] Button _defaultVolumeButton;

    [SerializeField] Slider _volumeSlider;

    [SerializeField] GameObject mainMenu;
    //[SerializeField] GameObject keybindsMenu;

    //[SerializeField] GameObject ground;

    private void Start()
    {
        //_keybindsButton.onClick.AddListener(HandleKeybindsClicked);
        _returnButton.onClick.AddListener(HandleReturnClicked);
        _defaultVolumeButton.onClick.AddListener(HandleDefaultVolumeClicked);
    }

    //void HandleKeybindsClicked()
    //{
    //    keybindsMenu.GetComponent<KeybindsManager>().SetPlaceholderTexts();

    //    gameObject.SetActive(false);
    //    keybindsMenu.SetActive(true);

    //    ground.SetActive(false);
    //}
    void HandleReturnClicked()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleDefaultVolumeClicked()
    {
        PlayerPrefsController.SetDefaultVolume();
        _volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        AudioManager.Instance.PlayMenuClick();
    }
}
