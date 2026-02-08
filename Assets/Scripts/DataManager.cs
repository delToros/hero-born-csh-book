using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// For filesystem
using System.IO;

using System;

public class DataManager : MonoBehaviour, IManager
{
    // For Interface
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    // Persistent Path
    private string _dataPath;

    // For new file
    private string _textFile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    private void Awake()
    {
        //_dataPath = Application.persistentDataPath + "/Player_Data/";
        _dataPath = Path.Combine(Application.persistentDataPath, "New_Player_Data");
        _textFile = Path.Combine(_dataPath, "Save_Data.txt");
        Debug.Log(_dataPath);
    }

    public void Initialize()
    {
        _state = "Data Manager Initialized";
        Debug.Log(_state);
        FileSystemInfo();
        NewDirectory();
        NewTextFile();
        UpdateTextFile();
    }

    public void FileSystemInfo()
    {
        Debug.Log($"Path Separator: {Path.PathSeparator}");
        Debug.Log($"Directory Separator: {Path.DirectorySeparatorChar}");
        Debug.Log($"Current directory: {Directory.GetCurrentDirectory()}");
        Debug.Log($"Temporary path: {Path.GetTempPath()}");
    }

    public void NewDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log($"Directory \"{_dataPath}\" already exists");
            return;
        }
        else
        {
            Directory.CreateDirectory(_dataPath);
            Debug.Log($"Directory \"{_dataPath}\" has been created");
        }
    }

    public void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Debug.Log($"Directory \"{_dataPath}\" does not exist!");
            return;
        }

        Directory.Delete(_dataPath, true);
        Debug.Log($"Directory \"{_dataPath}\" has been delted!");
    }

    public void NewTextFile()
    {
        if (File.Exists(_textFile))
        {
            Debug.Log($"File at the path \"{_textFile}\" already exists");
            return;
        }
        File.WriteAllText(_textFile, "<SAVE DATA>\n");
        Debug.Log($"New file at path \"{_textFile}\" created");
    }

    public void UpdateTextFile()
    {
        if (!File.Exists(_textFile))
        {
            Debug.Log($"File at the path \"{_textFile}\" does not exist!");
            return;
        }

        File.AppendAllText(_textFile, $"Game started: {DateTime.Now}");
        Debug.Log($"File at the path \"{_textFile}\" have been updated!");
    }
}
