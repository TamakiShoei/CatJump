using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    public void Change(string next_scene)
    {
        if (next_scene == "Game")
        {
            Application.targetFrameRate = 60;
        }
        else if (Application.targetFrameRate != 10)
        {
            Application.targetFrameRate = 10;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(next_scene);
    }
}
