using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtons : MonoBehaviour
{
    [SerializeField] Button quitButton;
    [SerializeField] Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(HandleMainMenuClicked);
        quitButton.onClick.AddListener(HandleQuitClicked);
    }

    void HandleMainMenuClicked()
    {
        GameManager.Instance.LoadMainMenu();
        AudioManager.Instance.PlayMenuClick();
    }
    void HandleQuitClicked()
    {
        AudioManager.Instance.PlayMenuClick();
        Application.Quit();
    }

    
}
