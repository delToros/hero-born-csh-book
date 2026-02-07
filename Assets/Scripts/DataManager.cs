using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// For filesystem
using System.IO;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    private void Awake()
    {
        //_dataPath = Application.persistentDataPath + "/Player_Data/";
        _dataPath = Path.Combine(Application.persistentDataPath, "New_Player_Data");
        Debug.Log(_dataPath);
    }

    public void Initialize()
    {
        _state = "Data Manager Initialized";
        Debug.Log(_state);
        FileSystemInfo();
    }

    public void FileSystemInfo()
    {
        Debug.Log($"Path Separator: {Path.PathSeparator}");
        Debug.Log($"Directory Separator: {Path.DirectorySeparatorChar}");
        Debug.Log($"Current directory: {Directory.GetCurrentDirectory()}");
        Debug.Log($"Temporary path: {Path.GetTempPath()}");
    }
}
