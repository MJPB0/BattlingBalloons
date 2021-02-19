using UnityEngine;
using UnityEngine.UI;

public class KeybindsManager : MonoBehaviour
{
    #region Player1 Keybinds Placeholders
    [Header("Player 1 Keybind Input Fields")]
    [SerializeField] InputField Player1MoveLeft;
    [SerializeField] InputField Player1MoveRight;
    [SerializeField] InputField Player1Jump;
    [SerializeField] InputField Player1Shoot;
    [SerializeField] InputField Player1RotateLeft;
    [SerializeField] InputField Player1RotateRight;

    [Space]
    [SerializeField] Text Player1MoveLeftPlaceholder;
    [SerializeField] Text Player1MoveRightPlaceholder;
    [SerializeField] Text Player1JumpPlaceholder;
    [SerializeField] Text Player1ShootPlaceholder;
    [SerializeField] Text Player1RotateLeftPlaceholder;
    [SerializeField] Text Player1RotateRightPlaceholder;
    #endregion

    #region Player2 Keybinds Placeholders
    [Header("Player 2 Keybind Input Fields")]
    [SerializeField] InputField Player2MoveLeft;
    [SerializeField] InputField Player2MoveRight;
    [SerializeField] InputField Player2Jump;
    [SerializeField] InputField Player2Shoot;
    [SerializeField] InputField Player2RotateLeft;
    [SerializeField] InputField Player2RotateRight;

    [Space]
    [SerializeField] Text Player2MoveLeftPlaceholder;
    [SerializeField] Text Player2MoveRightPlaceholder;
    [SerializeField] Text Player2JumpPlaceholder;
    [SerializeField] Text Player2ShootPlaceholder;
    [SerializeField] Text Player2RotateLeftPlaceholder;
    [SerializeField] Text Player2RotateRightPlaceholder;
    #endregion

    public void SetPlaceholderTexts()
    {
        Player1JumpPlaceholder.text = PlayerPrefsController.GetPlayer1Jump();
        Player1MoveLeftPlaceholder.text = PlayerPrefsController.GetPlayer1MoveLeft();
        Player1MoveRightPlaceholder.text = PlayerPrefsController.GetPlayer1MoveRight();
        Player1RotateLeftPlaceholder.text = PlayerPrefsController.GetPlayer1RotateLeft();
        Player1RotateRightPlaceholder.text = PlayerPrefsController.GetPlayer1RotateRight();
        Player1ShootPlaceholder.text = PlayerPrefsController.GetPlayer1Shoot();

        Player2JumpPlaceholder.text = PlayerPrefsController.GetPlayer2Jump();
        Player2MoveLeftPlaceholder.text = PlayerPrefsController.GetPlayer2MoveLeft();
        Player2MoveRightPlaceholder.text = PlayerPrefsController.GetPlayer2MoveRight();
        Player2RotateLeftPlaceholder.text = PlayerPrefsController.GetPlayer2RotateLeft();
        Player2RotateRightPlaceholder.text = PlayerPrefsController.GetPlayer2RotateRight();
        Player2ShootPlaceholder.text = PlayerPrefsController.GetPlayer2Shoot();
    }

    public void SaveKeybinds()
    {
        PlayerPrefsController.SetPlayer1Jump(Player1Jump.text);
        PlayerPrefsController.SetPlayer1MoveLeft(Player1MoveLeft.text);
        PlayerPrefsController.SetPlayer1MoveRight(Player1MoveRight.text);
        PlayerPrefsController.SetPlayer1RotateLeft(Player1RotateLeft.text);
        PlayerPrefsController.SetPlayer1RotateRight(Player1RotateRight.text);
        PlayerPrefsController.SetPlayer1Shoot(Player1Shoot.text);

        PlayerPrefsController.SetPlayer2Jump(Player2Jump.text);
        PlayerPrefsController.SetPlayer2MoveLeft(Player2MoveLeft.text);
        PlayerPrefsController.SetPlayer2MoveRight(Player2MoveRight.text);
        PlayerPrefsController.SetPlayer2RotateLeft(Player2RotateLeft.text);
        PlayerPrefsController.SetPlayer2RotateRight(Player2RotateRight.text);
        PlayerPrefsController.SetPlayer2Shoot(Player2Shoot.text);
    }
}
