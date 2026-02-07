using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

// For restarting the game
using UnityEngine.SceneManagement;

//Learning LINQ
using System.Linq;

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

    // For Stacks
    // option 1 - basic creatinion
    // public Stack<Loot> LootStack = new Stack<Loot>();

    // option 2 - The "Target-Typed New" (Most Modern)
    public Stack<Loot> LootStack = new();

    // option 3 - the var ketword
    // var lootStack = new Stack<Loot>();

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

        // For Stacks
        LootStack.Push(new Loot("Sword of Doom", 5));
        LootStack.Push(new Loot("HP Boost", 1));
        LootStack.Push(new Loot("Golden Key", 4));
        LootStack.Push(new Loot("Winged Boots", 2));
        LootStack.Push(new Loot("Mythril Bracer", 4));

        //FilterLoot();
        FilterLoot_Lambda();
    }

    public void PrintLootReport()
    {
        Debug.Log($"There are {LootStack.Count} loot items!");

        var initialItem = LootStack.Peek();
        Debug.Log($"{initialItem.Name} is the first PEEK item");

        var currentItem = LootStack.Pop();
        Debug.Log($"{currentItem.Name} is the first POP item");

        var nextItem = LootStack.Peek();
        Debug.Log($"{nextItem.Name} is the first PEEK item UPDATED");
    }

    public void FilterLoot()
    {
        var rareLoot = LootStack.Where(LootPredicate);

        foreach (var item in rareLoot)
        {
            Debug.Log($"Rare item: {item.Name}");
        }
    }

    public bool LootPredicate(Loot loot)
    {
        return loot.Rarity >= 3;
    }

    public void FilterLoot_Lambda()
    {
        // Long version
        /*
        var rareLoot = LootStack
            
            .Where(item => item.Rarity >= 3)
            .OrderBy(item => item.Rarity)

            // This is Anonymous Type
            .Select(item => new
            {
                item.Name
            });
            */

        // Simplified virsion
        var rareLoot = from item in LootStack
                       where item.Rarity >= 3
                       orderby item.Rarity
                       select item;
                       // for anonymous type:
                       // select new {item.name}


        foreach (var item in rareLoot)
        {
            Debug.Log($"Rare YY item: {item.Name}");
        }
    }
}
