using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreboardUI : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;

    [SerializeField] Text player1RoundsWon;
    [SerializeField] Text player1OverallScore;

    [SerializeField] Text player2RoundsWon;
    [SerializeField] Text player2OverallScore;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
        quitButton.onClick.AddListener(HandleQuitButtonClicked);

        ProcessScore();
    }

    void HandleMainMenuClicked()
    {
        GameManager.Instance.LoadMainMenu();

        GameManager.Instance.ScoreBoard.Clear();
        GameManager.Instance.CurrentRound = 1;
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleQuitButtonClicked()
    {
        AudioManager.Instance.PlayMenuClick();
        Application.Quit();
    }

    void ProcessScore()
    {
        int score1 = 0, score2 = 0, rounds1 = 0, rounds2 = 0;

        for(int i = 0; i < GameManager.Instance.ScoreBoard.Count; i++)
        {
            string s = GameManager.Instance.ScoreBoard[i];

            int[] nums = new int[2];

            string pom = "";
            int index = 0;

            for(int j = 0; j < s.Length; j++)
            {
                if (s[j] == ';')
                {
                    if(index == 0)
                    {
                        nums[0] = Convert.ToInt32(pom);
                        score1 += Convert.ToInt32(pom);
                    }else if(index == 1)
                    {
                        nums[1] = Convert.ToInt32(pom);
                        score2 += Convert.ToInt32(pom);
                    }

                    index++;
                    pom = "";
                }
                else
                {
                    pom += s[j];
                }
            }

            if (nums[0] > nums[1])
                rounds1++;
            else if (nums[0] < nums[1])
                rounds2++;
            else if (nums[0] == nums[1])
            {
                rounds1++;
                rounds2++;
            }
        }

        player1RoundsWon.text = rounds1.ToString();
        player1OverallScore.text = score1.ToString();

        player2RoundsWon.text = rounds2.ToString();
        player2OverallScore.text = score2.ToString();
    }
}
