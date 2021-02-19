using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using System;

public class RoundConfiguration : MonoBehaviour
{
    [SerializeField] Dropdown _roundTime;
    [SerializeField] Dropdown _roundCount;

    private void Start()
    {
        _roundTime.value = 5;
        _roundCount.value = 2;
    }

    public void RoundTimeChanged()
    {
        PlayerPrefsController.SetRoundsTime((_roundTime.value != 0) ? _roundTime.value * 60 : 30f);
    }
    public void RoundCountChanged()
    {
        PlayerPrefsController.SetRoundsCount(_roundCount.value + 1);
    }
}
