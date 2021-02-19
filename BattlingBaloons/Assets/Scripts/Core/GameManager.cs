using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { PREGAME, PLAYING, PAUSED, DIALOGUE};

    [SerializeField] GameState currentGameState = GameState.PREGAME;
    public GameState CurrentGameState { get { return currentGameState; } private set { currentGameState = value; } }
    GameState previousState;
    public GameState PreviousState { get { return previousState; } }

    [SerializeField] int currentLevel;
    public int CurrentLevel { get { return currentLevel; } }

    public EventGameState OnGameStateChanged;

    [SerializeField] List<string> scoreBoard;

    public List<string> ScoreBoard { get { return scoreBoard; } }

    [SerializeField] int currentRound = 1;
    public int CurrentRound { get { return currentRound; } set { currentRound = value; } }

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
        PlayerPrefsController.SetDefaultSettings();

        UpdateGameState(GameState.PREGAME);
    }

    public void UpdateGameState(GameState gameState)
    {
        previousState = currentGameState;
        currentGameState = gameState;

        switch (currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1f;
                break;
            case GameState.PLAYING:
                Time.timeScale = 1f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            case GameState.DIALOGUE:
                Time.timeScale = 1f;
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(currentGameState, previousState);
    }

    public void StartGame(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);

        UpdateGameState(GameState.PLAYING);
        currentLevel = SceneManager.GetSceneByName(levelName).buildIndex;
    }

    public void LoadNextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel += 1;

        SceneManager.LoadSceneAsync(currentLevel, LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

        UpdateGameState(GameState.PREGAME);
    }

    public void LoadScoreboard()
    {
        SceneManager.LoadSceneAsync("Scoreboard", LoadSceneMode.Single);
    }
}
