using UnityEngine;
using TMPro;
using UnityEngine.UI;

// For restarting the game
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour, IManager
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    // For UI
    public int MaxItems = 4;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

    // For Win Condition
    public Button WinButton;

    // For Loose condition
    public Button LossButton;

    // For Interface
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }


    private void Start()
    {
        // For displaying initial values (0)
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;

        Initialize();
    }

    // This var will be modified in item behavior script
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            ItemText.text = "Items: " + Items;

            if (_itemsCollected >= MaxItems)
            {
                // For win condition
                WinButton.gameObject.SetActive(true);
                UpdateScene("You've found all the Items!");
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more!";
            }

                Debug.Log($"Items: {_itemsCollected}");
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + _playerHP;
            Debug.Log($"Lives: {_playerHP}");

            if (_playerHP <= 0)
            {
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "You got hit, bro";
            }
        }
    }

    public void RestartScene()
    {
        Utilities.RestartLevel(0);
    }

    public void UpdateScene(string updateText)
    {
        ProgressText.text = updateText;
        Time.timeScale = 0;
    }

    //For Interface
    public void Initialize()
    {
        _state = "Game Manager initialized";
        Debug.Log(_state);
    }
}
