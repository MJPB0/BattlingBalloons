using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeSelection : MonoBehaviour
{
    [SerializeField] Button pvpButton;
    [SerializeField] Button returnButton;
    [SerializeField] Button tutorialButton;

    [SerializeField] GameObject pvpMapSelection;
    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject ground;

    private void Start()
    {
        pvpButton.onClick.AddListener(HandlePvPButtonClicked);
        returnButton.onClick.AddListener(HandleReturnClicked);
        tutorialButton.onClick.AddListener(HandleTutorialClicked);
    }

    void HandlePvPButtonClicked()
    {
        pvpMapSelection.SetActive(true);
        gameObject.SetActive(false);
        ground.SetActive(false);

        AudioManager.Instance.PlayMenuClick();
    }
    void HandleReturnClicked()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleTutorialClicked()
    {
        SceneManager.LoadSceneAsync("Tutorial", LoadSceneMode.Single);
        AudioManager.Instance.PlayMenuClick();
    }
}
