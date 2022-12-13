using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    public void Change(string next_scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(next_scene);
    }
}
