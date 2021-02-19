using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindsMenu : MonoBehaviour
{
    [SerializeField] Button _returnButton;
    [SerializeField] GameObject optionsMenu;

    [SerializeField] GameObject ground;

    [SerializeField] GameObject returnScreen;

    [SerializeField] Button saveKeybindsButton;
    [SerializeField] Button discardKeybindsButton;
    private void Start()
    {
        _returnButton.onClick.AddListener(HandleReturnClicked);

        discardKeybindsButton.onClick.AddListener(HandleDiscardKeybindsClicked);
        saveKeybindsButton.onClick.AddListener(HandleSaveKeybindsClicked);
    }

    void HandleReturnClicked()
    {
        returnScreen.SetActive(true);
    }

    void ToggleOptionsMenu()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
        returnScreen.SetActive(false);

        ground.SetActive(true);
    }
    void HandleDiscardKeybindsClicked()
    {
        ToggleOptionsMenu();
    }
    void HandleSaveKeybindsClicked()
    {
        GetComponent<KeybindsManager>().SaveKeybinds();

        ToggleOptionsMenu();
    }
}
