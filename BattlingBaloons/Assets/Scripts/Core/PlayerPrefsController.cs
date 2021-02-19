using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController
{
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_ROUND_COUNT = 1;
    const int MAX_ROUND_COUNT = 6;
    public static float GetMaxRoundCount { get { return MAX_ROUND_COUNT; } }
    public static float GetMinRoundCount { get { return MIN_ROUND_COUNT; } }

    const float MIN_ROUND_TIME = 30f;
    const float MAX_ROUND_TIME = 360f;
    public static float GetMaxRoundTime { get { return MAX_ROUND_TIME; } }
    public static float GetMinRoundTime { get { return MIN_ROUND_TIME; } }

    const string MASTER_VOLUME_KEY = "Master Volume";

    const string ROUNDS_TO_PLAY_KEY = "Rounds Count";
    const string ROUND_TIME_KEY = "Round Time";

    #region Player 1 Keybinds
        const string PLAYER_1_MOVE_LEFT_KEY = "Player 1 Move Left";
        const string PLAYER_1_MOVE_RIGHT_KEY = "Player 1 Move Right";
        const string PLAYER_1_SHOOT_KEY = "Player 1 Shoot";
        const string PLAYER_1_JUMP_KEY = "Player 1 Jump";
        const string PLAYER_1_ROTATE_LEFT_KEY = "Player 1 Rotate Left";
        const string PLAYER_1_ROTATE_RIGHT_KEY = "Player 1 Rotate Right";
    #endregion

    #region Player 2 Keybinds
        const string PLAYER_2_MOVE_LEFT_KEY = "Player 2 Move Left";
        const string PLAYER_2_MOVE_RIGHT_KEY = "Player 2 Move Right";
        const string PLAYER_2_SHOOT_KEY = "Player 2 Shoot";
        const string PLAYER_2_JUMP_KEY = "Player 2 Jump";
        const string PLAYER_2_ROTATE_LEFT_KEY = "Player 2 Rotate Left";
        const string PLAYER_2_ROTATE_RIGHT_KEY = "Player 2 Rotate Right";
    #endregion

    #region Default Settings
        const float MASTER_VOLUME_DEFAULT = .6f;

        const int ROUNDS_TO_PLAY_DEFAULT = 3;
        const float ROUND_TIME_DEFAULT = 300f;


        #region Player 1 Keybinds
        const string PLAYER_1_MOVE_LEFT_DEFAULT = "a";
        const string PLAYER_1_MOVE_RIGHT_DEFAULT = "d";
        const string PLAYER_1_SHOOT_DEFAULT = "y";
        const string PLAYER_1_JUMP_DEFAULT = "w";
        const string PLAYER_1_ROTATE_LEFT_DEFAULT = "r";
        const string PLAYER_1_ROTATE_RIGHT_DEFAULT = "t";
        #endregion

        #region Player 2 Keybinds
        const string PLAYER_2_MOVE_LEFT_DEFAULT = "left";
        const string PLAYER_2_MOVE_RIGHT_DEFAULT = "right";
        const string PLAYER_2_SHOOT_DEFAULT = "l";
        const string PLAYER_2_JUMP_DEFAULT = "up";
        const string PLAYER_2_ROTATE_LEFT_DEFAULT = "j";
        const string PLAYER_2_ROTATE_RIGHT_DEFAULT = "k";
    #endregion
    #endregion

    #region 'Set' Methods
    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master Volume not set properly!");
    }

    public static void SetRoundsCount(int value)
    {
        if (value >= MIN_ROUND_COUNT && value <= MAX_ROUND_COUNT)
            PlayerPrefs.SetInt(ROUNDS_TO_PLAY_KEY, value);
        else
            Debug.LogError("Rounds count not set properly!");
    }

    public static void SetRoundsTime(float value)
    {
        if (value >= MIN_ROUND_TIME && value <= MAX_ROUND_TIME)
            PlayerPrefs.SetFloat(ROUND_TIME_KEY, value);
        else
            Debug.LogError("Rounds time not set properly!");
    }
    #endregion

    #region 'Get' Methods

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static float GetRoundTime()
    {
        return PlayerPrefs.GetFloat(ROUND_TIME_KEY);
    }
    public static int GetRoundsCount()
    {
        return PlayerPrefs.GetInt(ROUNDS_TO_PLAY_KEY);
    }

    #endregion

    #region Player 1 Keybinds public Methods
    #region Set Keybinds
    public static void SetPlayer1MoveLeft(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_1_MOVE_LEFT_KEY, keybind);
    }
    public static void SetPlayer1MoveRight(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_1_MOVE_RIGHT_KEY, keybind);
    }
    public static void SetPlayer1Jump(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_1_JUMP_KEY, keybind);
    }
    public static void SetPlayer1Shoot(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_1_SHOOT_KEY, keybind);
    }
    public static void SetPlayer1RotateLeft(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_1_ROTATE_LEFT_KEY, keybind);
    }
    public static void SetPlayer1RotateRight(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_1_ROTATE_RIGHT_KEY, keybind);
    }
    #endregion
    #region Get Keybinds
    public static string GetPlayer1MoveLeft()
    {
        return PlayerPrefs.GetString(PLAYER_1_MOVE_LEFT_KEY);
    }
    public static string GetPlayer1MoveRight()
    {
        return PlayerPrefs.GetString(PLAYER_1_MOVE_RIGHT_KEY);
    }
    public static string GetPlayer1Jump()
    {
        return PlayerPrefs.GetString(PLAYER_1_JUMP_KEY);
    }
    public static string GetPlayer1Shoot()
    {
        return PlayerPrefs.GetString(PLAYER_1_SHOOT_KEY);
    }
    public static string GetPlayer1RotateLeft()
    {
        return PlayerPrefs.GetString(PLAYER_1_ROTATE_LEFT_KEY);
    }
    public static string GetPlayer1RotateRight()
    {
        return PlayerPrefs.GetString(PLAYER_1_ROTATE_RIGHT_KEY);
    }
    #endregion
    #endregion

    #region Player 2 Keybinds public Methods
    #region Set Keybinds
    public static void SetPlayer2MoveLeft(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_2_MOVE_LEFT_KEY, keybind);
    }
    public static void SetPlayer2MoveRight(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_2_MOVE_RIGHT_KEY, keybind);
    }
    public static void SetPlayer2Jump(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_2_JUMP_KEY, keybind);
    }
    public static void SetPlayer2Shoot(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_2_SHOOT_KEY, keybind);
    }
    public static void SetPlayer2RotateLeft(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_2_ROTATE_LEFT_KEY, keybind);
    }
    public static void SetPlayer2RotateRight(string keybind)
    {
        PlayerPrefs.SetString(PLAYER_2_ROTATE_RIGHT_KEY, keybind);
    }
    #endregion
    #region Get Keybinds
    public static string GetPlayer2MoveLeft()
    {
        return PlayerPrefs.GetString(PLAYER_2_MOVE_LEFT_KEY);
    }
    public static string GetPlayer2MoveRight()
    {
        return PlayerPrefs.GetString(PLAYER_2_MOVE_RIGHT_KEY);
    }
    public static string GetPlayer2Jump()
    {
        return PlayerPrefs.GetString(PLAYER_2_JUMP_KEY);
    }
    public static string GetPlayer2Shoot()
    {
        return PlayerPrefs.GetString(PLAYER_2_SHOOT_KEY);
    }
    public static string GetPlayer2RotateLeft()
    {
        return PlayerPrefs.GetString(PLAYER_2_ROTATE_LEFT_KEY);
    }
    public static string GetPlayer2RotateRight()
    {
        return PlayerPrefs.GetString(PLAYER_2_ROTATE_RIGHT_KEY);
    }
    #endregion
    #endregion

    public static void SetDefaultKeybinds()
    {
        SetPlayer1Jump(PLAYER_1_JUMP_DEFAULT);
        SetPlayer1MoveLeft(PLAYER_1_MOVE_LEFT_DEFAULT);
        SetPlayer1MoveRight(PLAYER_1_MOVE_RIGHT_DEFAULT);
        SetPlayer1RotateLeft(PLAYER_1_ROTATE_LEFT_DEFAULT);
        SetPlayer1RotateRight(PLAYER_1_ROTATE_RIGHT_DEFAULT);
        SetPlayer1Shoot(PLAYER_1_SHOOT_DEFAULT);

        SetPlayer2Jump(PLAYER_2_JUMP_DEFAULT);
        SetPlayer2MoveLeft(PLAYER_2_MOVE_LEFT_DEFAULT);
        SetPlayer2MoveRight(PLAYER_2_MOVE_RIGHT_DEFAULT);
        SetPlayer2RotateLeft(PLAYER_2_ROTATE_LEFT_DEFAULT);
        SetPlayer2RotateRight(PLAYER_2_ROTATE_RIGHT_DEFAULT);
        SetPlayer2Shoot(PLAYER_2_SHOOT_DEFAULT);
    }

    public static void SetDefaultSettings()
    {
        SetMasterVolume(MASTER_VOLUME_DEFAULT);

        SetRoundsCount(ROUNDS_TO_PLAY_DEFAULT);
        SetRoundsTime(ROUND_TIME_DEFAULT);
    }
    public static void SetDefaultVolume()
    {
        SetMasterVolume(MASTER_VOLUME_DEFAULT);
    }
}
