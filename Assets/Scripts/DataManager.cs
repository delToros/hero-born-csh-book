using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour, IManager
{
    //For Interface
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Data Manager Initialized";
        Debug.Log(_state);
    }
}
