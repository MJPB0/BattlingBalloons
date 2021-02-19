using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvPMapSelection : MonoBehaviour
{
    [SerializeField] Button returnButton;

    [SerializeField] Button _map1;
    [SerializeField] Button _map2;
    [SerializeField] Button _map3;
    [SerializeField] Button _map4;

    [SerializeField] GameObject gameModeSelection;

    [SerializeField] GameObject ground;

    private void Start()
    {
        returnButton.onClick.AddListener(HandleReturnClicked);

        _map1.onClick.AddListener(HandleMap1Clicked);
        _map2.onClick.AddListener(HandleMap2Clicked);
        _map3.onClick.AddListener(HandleMap3Clicked);
        _map4.onClick.AddListener(HandleMap4Clicked);
    }
    void HandleReturnClicked()
    {
        gameModeSelection.SetActive(true);
        gameObject.SetActive(false);

        ground.SetActive(true);
        AudioManager.Instance.PlayMenuClick();
    }

    void HandleMap1Clicked()
    {
        GameManager.Instance.StartGame("Level 0");
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleMap2Clicked()
    {
        GameManager.Instance.StartGame("Level 1");
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleMap3Clicked()
    {
        GameManager.Instance.StartGame("Level 2");
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleMap4Clicked()
    {
        GameManager.Instance.StartGame("Level 3");
        AudioManager.Instance.PlayMenuClick();
    }
}
