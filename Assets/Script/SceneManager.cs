using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip titleBGM;
    [SerializeField]
    AudioClip gameBGM;
    [SerializeField]
    AudioClip resultBGM;
    [SerializeField]
    AudioClip recordBGM;

    private void Start()
    {
        soundManager.PlayBgm(titleBGM);
    }

    public void Change(string next_scene)
    {
        if (next_scene == "Game")
        {
            soundManager.PlayBgm(gameBGM);
            Application.targetFrameRate = 60;
        }
        else if (next_scene == "Title")
        {
            soundManager.PlayBgm(titleBGM);
            Application.targetFrameRate = 10;
        }
        else if (next_scene == "Result")
        {
            soundManager.PlayBgm(resultBGM);
            Application.targetFrameRate = 10;
        }
        else if (next_scene == "Record")
        {
            soundManager.PlayBgm(recordBGM);
            Application.targetFrameRate = 10;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(next_scene);
    }
}
