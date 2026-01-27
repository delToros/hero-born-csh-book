using UnityEngine;
using TMPro;
using UnityEngine.UI;

// For restarting the game
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
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

    



    private void Start()
    {
        // For displaying initial values (0)
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
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
                ProgressText.text = "You've found all the Items!";

                // For win condition
                WinButton.gameObject.SetActive(true);

                // For pausing the game
                Time.timeScale = 0;
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
            Debug.Log($"Lives: {_playerHP}");
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
