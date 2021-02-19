using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    public UnityAction OnRoundEnded;

    [Header("Round")]
    [SerializeField] int roundCount;

    [Space]
    [SerializeField] float roundTime;
    [SerializeField] float noAmmoDeathTime;
    public bool timeRunning { get; set; }

    [Space]
    [SerializeField] Slider roundTimeSlider;
    [SerializeField] Slider noAmmoDeathSlider;

    [Space]
    [SerializeField] GameObject countdownIndicator;

    [Space]
    [SerializeField] GameObject nextRound;

    public int RoundCount { get { return roundCount; } set { roundCount = value; } }

    private void Start()
    {
        roundCount = PlayerPrefsController.GetRoundsCount();

        roundTime = PlayerPrefsController.GetRoundTime();
        roundTimeSlider.maxValue = PlayerPrefsController.GetRoundTime();

        OnRoundEnded += RoundEnded;
    }

    private void Update()
    {
        if (PlayerManager.Instance.Player1.OutOFAmmo && PlayerManager.Instance.Player2.OutOFAmmo)
        {
            CountDeathTime();
        }
        else if ((!PlayerManager.Instance.Player1.OutOFAmmo || !PlayerManager.Instance.Player2.OutOFAmmo) && noAmmoDeathSlider.value < 5f)
        {
            noAmmoDeathTime = 5f;
            noAmmoDeathSlider.value = noAmmoDeathTime;
        }

        if(timeRunning)
            CountRoundTime();
    }
    void CountRoundTime()
    {
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;
            roundTimeSlider.value = roundTime;
        }
        else if (roundTime <= 0)
        {
            roundTime = PlayerPrefsController.GetRoundTime();
            roundTimeSlider.value = roundTime;

            // Debug.Log("[Round Manager] Round time ended.");
            OnRoundEnded?.Invoke();
        }
    }
    void CountDeathTime()
    {
        if (noAmmoDeathTime > 0)
        {
            noAmmoDeathTime -= Time.deltaTime;
            noAmmoDeathSlider.value = noAmmoDeathTime;
        }
        else
        {
            noAmmoDeathTime = 5f;
            noAmmoDeathSlider.value = noAmmoDeathTime;

            PlayerManager.Instance.Player1.Die();
            PlayerManager.Instance.Player2.Die();
        }
    }
    void RoundEnded()
    {
        //Debug.Log("Round Ended!");
        AddRoundToScoreboard();
        GameManager.Instance.CurrentRound++;

        if (GameManager.Instance.CurrentRound == roundCount + 1)
        {
            //Debug.Log("[Round Manager] Loaded Scoreboard. " + GameManager.Instance.CurrentRound + " : " + RoundCount + ";");
            GameManager.Instance.LoadScoreboard();
            GameManager.Instance.CurrentRound = 1;
        }
        else if (GameManager.Instance.CurrentRound < roundCount + 1)
        {
           // Debug.Log("[Round Manager] Restarted Level. " + GameManager.Instance.CurrentRound + " : " + RoundCount + ";");
            RestartRound();

            FindObjectOfType<GameUI>().UpdateCurrentRoundText();
        }
    }
    void AddRoundToScoreboard()
    {
        string scoreToSave = PlayerManager.Instance.Player1.Score + ";" + PlayerManager.Instance.Player2.Score + ";";

        GameManager.Instance.ScoreBoard.Add(scoreToSave);
    }

    void RestartRound()
    {
        Player[] players = FindObjectsOfType<Player>();

        for (int i = 0; i < 2; i++)
        {
            players[i].ResetPlayer();
        }

        ResetGameUI();

        StartCoroutine(WaitAndStartCountingTime(players[0], players[1]));
    }

    IEnumerator WaitAndStartCountingTime(Player player1, Player player2)
    {
        timeRunning = false;

        yield return new WaitForSeconds(5f);

        timeRunning = true;
    }

    void ResetGameUI()
    {
        PlayerManager.Instance.Player1.Score = 0;
        PlayerManager.Instance.Player2.Score = 0;
        PlayerManager.Instance.UpdateScoreBoard();
        PlayerManager.Instance.ClearPlayersCombos();
    }
}
