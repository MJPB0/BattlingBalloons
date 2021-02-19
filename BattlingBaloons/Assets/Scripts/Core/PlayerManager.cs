using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] int player1Combo;
    [SerializeField] int player2Combo;

    public int Player1Combo { get { return player1Combo; } }
    public int Player2Combo { get { return player2Combo; } }

    [SerializeField] Text player1ComboText;
    [SerializeField] Text player2ComboText;

    [SerializeField] Text scoreBoardText;
    [SerializeField] Player player1;
    [SerializeField] Player player2;

    public Player Player1 { get { return player1; } }
    public Player Player2 { get { return player2; } }

    public Action Player1Died;
    public Action Player2Died;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public void Player1AddPoint()
    {
        player1.Score++;
        UpdateScoreBoard();
    }
    public void Player2AddPoint()
    {
        player2.Score++;
        UpdateScoreBoard();
    }

    public void Player1AddWater()
    {
        player1.AddWater();
    }
    public void Player2AddWater()
    {
        player2.AddWater();
    }

    public void UpdateScoreBoard()
    {
        scoreBoardText.text = player1.Score + ":" + player2.Score;
    }

    public void TriggerPlayer1Died()
    {
        Player1Died?.Invoke();
    }
    public void TriggerPlayer2Died()
    {
        Player2Died?.Invoke();
    }

    public void IncreasePlayer1Combo()
    {
        player2ComboText.gameObject.SetActive(false);
        player1ComboText.gameObject.SetActive(true);

        player2Combo = 0;
        player1Combo++;

        player1ComboText.text = "x" + player1Combo.ToString();
    }
    public void IncreasePlayer2Combo()
    {
        player1ComboText.gameObject.SetActive(false);
        player2ComboText.gameObject.SetActive(true);

        player1Combo = 0;
        player2Combo++;

        player2ComboText.text = "x" + player2Combo.ToString();
    }
    public void ClearPlayersCombos()
    {
        player1ComboText.gameObject.SetActive(false);
        player2ComboText.gameObject.SetActive(false);

        player1Combo = 0;
        player2Combo = 0;
    }
}
