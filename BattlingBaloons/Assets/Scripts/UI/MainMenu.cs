using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _quitButton;

    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject gameModeSelectionMenu;

    private void Start()
    {
        _playButton.onClick.AddListener(HandlePlayClicked);
        _optionsButton.onClick.AddListener(HandleOptionsClicked);
        _quitButton.onClick.AddListener(HandleQuitClicked);
    }

    void HandlePlayClicked()
    {
        gameModeSelectionMenu.SetActive(true);
        gameObject.SetActive(false);
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleOptionsClicked()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleQuitClicked()
    {
        AudioManager.Instance.PlayMenuClick();
        Application.Quit();
    }
}
