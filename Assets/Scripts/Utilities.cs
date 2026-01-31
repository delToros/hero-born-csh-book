using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;


public static class Utilities
{
    public static int PlayerDeaths = 0;

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

    }

    public static bool RestartLevel(int SceneIndex)
    {
        // for ref
        Debug.Log($"Intial deaths {PlayerDeaths}");
        string message = UpdateDeathCount(ref PlayerDeaths);
        Debug.Log($"After UpdteDeathCount deaths: {PlayerDeaths}");
        Debug.Log(message);

        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1;

        return true;

        
    }

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return $"Inside UpdateDeathCount deaths {countReference}";
    }
}
