using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;

    [SerializeField] Text currentRound;

    [SerializeField] GameObject pausedGameUI;

    private void Start()
    {
        pauseButton.onClick.AddListener(HandlePauseClicked);
        mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
        quitButton.onClick.AddListener(HandleQuitClicked);

        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        UpdateCurrentRoundText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.CurrentGameState == GameManager.GameState.PLAYING)
        {
            TogglePauseGameUI(true);
            GameManager.Instance.UpdateGameState(GameManager.GameState.PAUSED);
        }
    }

    void HandlePauseClicked()
    {
        TogglePauseGameUI(true);
        GameManager.Instance.UpdateGameState(GameManager.GameState.PAUSED);
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

    public void HandleGameStateChanged(GameManager.GameState current, GameManager.GameState previous)
    {
        if (current == GameManager.GameState.PREGAME && (previous == GameManager.GameState.PLAYING || previous == GameManager.GameState.PAUSED))
        {
            GameManager.Instance.LoadMainMenu();
        }
    }

    void TogglePauseGameUI(bool active)
    {
        gameObject.SetActive(!active);
        pausedGameUI.SetActive(active);
    }

    public void UpdateCurrentRoundText()
    {
        currentRound.text = GameManager.Instance.CurrentRound.ToString();
    }
}
