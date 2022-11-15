using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private int score;
    private bool isGameFinish;

    public void Initialize()
    {
        score = 0;
        isGameFinish = false;
    }

    public void ChangeScene(string next_scene)
    {
        SceneManager.LoadScene(next_scene);
    }

    public void IncrementScore(int val)
    {
        score += val;
    }

    public int GetScore()
    {
        return score;
    }

    public void GameFinished()
    {
        isGameFinish = true;
    }

    public bool GetIsGameFinish()
    {
        return isGameFinish;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instance.ChangeScene("Game");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instance.ChangeScene("Result");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instance.ChangeScene("Record");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instance.ChangeScene("Title");
        }
    }
}
