using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using static UnityEditor.Progress;

public class LearningCurve : MonoBehaviour
{

    public int CurrentAge = 30;
    public int YearsToAd = 1;
    public string CharacterAction = "Attack";

    public Transform CamTransform;
    public GameObject DirectionalLight;
    public Transform LightTransform;

    // enums
    // Basic definition
    enum PlayerAction { Attack, Defend, Flee};

    // enum with underlaying type
    enum NewPlayerAction { Attack = 5, Defend = 8, Flee };

    int MyInteger = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(30 + 1);
        //Debug.Log(CurrentAge + 1);
        //ComputeAge();

        //float MyFloat = 3.14f;
        //int ExcplicitConverstion = (int)MyFloat;
        //Debug.Log(ExcplicitConverstion);

        //PrintCharacterAction();

        WorkingWithClasses();

        CamTransform = this.GetComponent<Transform>();
        Debug.Log(CamTransform.localPosition);

        DirectionalLight = GameObject.Find("Directional Light");
        LightTransform = DirectionalLight.GetComponent<Transform>();

        Debug.Log(LightTransform.localPosition);

        // Or easier way
        LightTransform = GameObject.Find("Directional Light").GetComponent<Transform>();

    }

    public void PrintCharacterAction()
    {
        switch (CharacterAction)
        {
            case "Heal":
                Debug.Log("Potion Sent.");
                break;
            case "Attack":
                Debug.Log("To arms!");
                break;
            default:
                Debug.Log("Shields Up!");
                break;
        }
    }
    /// <summary>
    /// Basic operations with arrays
    /// </summary>
    public void DeclaringArray()
    {
        // Basic declaration
        int[] TopPlayerScores = new int[3];

        //Debug.Log($"This is how EMPTY array is printed: {TopPlayerScores}");

        // Longhand initilizer
        int[] NextTopPlayerScores = new int[] { 21, 233, 899 };

        //Debug.Log($"This is how FULL array is printed: {NextTopPlayerScores}");

        // Shorthand initilizer
        int[] NextNextTopPlayerScores = { 21, 233, 899 };

        // Retrive data from array
        int score = TopPlayerScores[1];

        // Subscript (change existing data)
        TopPlayerScores[1] = 555;

        //Debug.Log($"This is first array modyfied: {TopPlayerScores}");

        // Modern way
        Debug.Log($"Scores: {string.Join(", ", TopPlayerScores)}");

        // Using JsonUtility
        Debug.Log(JsonUtility.ToJson(new { scores = TopPlayerScores }));
    }

    /// <summary>
    /// About multidimentional arrays
    /// </summary>
    public void MultidimensionalArrays()
    {
        // The coordinates array has 3 rows and 2 columns
        int[,] Coodinates = new int[3, 2];

        // Initilizing m-array
        int[,] NewCoordinates = new int[3, 2]
        {
            {5,4},
            {1,7},
            {9,3}
        };

        // Proper printing out array
        string arrayString = "";

        for (int i = 0; i < NewCoordinates.GetLength(0); i++)
        {
            for (int j = 0; j < NewCoordinates.GetLength(1); j++)
            {
                arrayString += NewCoordinates[i, j] + " ";
            }
            arrayString += "\n";
        }
        Debug.Log(arrayString);

        // Accessing values
        Debug.Log(NewCoordinates[0, 0]);

        // Changing value
        NewCoordinates[0, 0] = 100;
        Debug.Log(NewCoordinates[0, 0]);

        // lengh methods
        Debug.Log($"This is simple lenght: {NewCoordinates.Length}");
        Debug.Log($"This is GetLenght at 0: {NewCoordinates.GetLength(0)}");
        Debug.Log($"This is GetLenght at 1: {NewCoordinates.GetLength(1)}");

    }

    public void AllAboutLists()
    {
        // Declaring empty list
        List<string> QuestPartyMembers = new List<string>()
        {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling the Knight"
        };

        // Count
        Debug.Log($"This is count: {QuestPartyMembers.Count}");

        // Add
        QuestPartyMembers.Add("Craven the Necromancer");
        Debug.Log($"Print new list: {string.Join(",", QuestPartyMembers)}");

        // Insert
        QuestPartyMembers.Insert(1, "Tanis the Tief");

        // Remove at position
        QuestPartyMembers.RemoveAt(0);

        // Remove specific element
        QuestPartyMembers.Remove("Grim the Barbarian");

    }

    public void AllAboutDicts()
    {
        // Creating list (Basic)
        Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
        {
            { "Potion", 5 },
            { "Antidote", 7 },
            { "Aspirin", 1 }
        };

        // Shorter Creation
        var NewInventory = new Dictionary<string, int>()
        {
            { "Potion", 5 },
            { "Antidote", 7 },
            { "Aspirin", 1 }
        };

        // C# 9 Shorthand (Target-typed new)
        Dictionary<string, int> ModernInventory = new()
        {
            { "Potion", 5 },
            { "Antidote", 7 },
            { "Aspirin", 1 }
        };

        // Manual printing out dict
        foreach (var item in ItemInventory)
        {
            Debug.Log($"Key: {item.Key}, Value: {item.Value}");
        }

        // Count
        Debug.Log($"Items: {ItemInventory.Count}");

        // Access values
        int numberOfPotions = ItemInventory["Potion"];

        // Set value
        ItemInventory["Potion"] = 10;

        // Add item with Add() method
        ItemInventory.Add("Throwing Knife", 3);

        // Add item with subscript
        ItemInventory["Bandage"] = 5;

        // Remove key-value pair
        ItemInventory.Remove("Antidote");
    }

    private void SmallChallenge()
    {
        Dictionary<string, int> GoldInventory = new()
        {
            {"Mouse", 5 },
            {"Sheep", 78 },
            {"Dragon", 178890 },
            {"Tim the Duck", 99999999 }
        };

        foreach (var item in GoldInventory)
        {
            if (item.Value > 500000)
            {
                Debug.Log($"Wtf, {item.Key}, how the hell did you get {item.Value} gold??!!");
            }
        }
    }

    public void WorkingWithClasses()
    {
        // Creating class instance
        Character hero = new Character();

        // Shorter creation
        Character newHero = new();

        // or inferred decdeclaration
        var nexthero = new Character();

        var anotherHero = new Character("Tim the Duck");

        // Using Methods
        //anotherHero.PrintStatsInfo();
        //nexthero.PrintStatsInfo();

        Character assistant = nexthero;

        //nexthero.PrintStatsInfo();
        //assistant.PrintStatsInfo();

        assistant.Name = "Sam the Catfish";

        //nexthero.PrintStatsInfo();
        //assistant.PrintStatsInfo();

        var newPaladin = new Paladin("Tom the Swan");


    }

    public void WorkingWithStructs()
    {
        var huntingBow = new Weapon("Hunting Bow", 105);
        huntingBow.PrintWeaponStats();
    }


    public void WorkingWithEnums()
    {

    }


    ///<summary>
    /// Calculates a modified age by adding 2 variables together
    ///</summary>
    void ComputeAge()
    {
        Debug.Log(CurrentAge + YearsToAd);
    }

    // Update is called once per frame
    void Update()
    {

    }

  
}
