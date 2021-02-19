using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedGameUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;

    [SerializeField] GameObject gameUI;

    private void Start()
    {
        resumeButton.onClick.AddListener(HandleResumeClicked);
        mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
        quitButton.onClick.AddListener(HandleQuitClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.CurrentGameState == GameManager.GameState.PAUSED)
        {
            ToggleGameUI(true);
            GameManager.Instance.UpdateGameState(GameManager.GameState.PLAYING);
        }
    }

    void HandleResumeClicked()
    {
        ToggleGameUI(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.PLAYING);
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleMainMenuClicked()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.PREGAME);
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleQuitClicked()
    {
        AudioManager.Instance.PlayMenuClick();
        Application.Quit();
    }

    void ToggleGameUI(bool active)
    {
        gameUI.SetActive(active);
        gameObject.SetActive(!active);
        AudioManager.Instance.PlayMenuClick();
    }
}
