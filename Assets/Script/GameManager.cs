using System;
using System.Collections;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private int score;
    private bool isGameFinish;
    [SerializeField]
    //private GameObject eventSystem;

    private void Start()
    {
        //if (GameObject.Find("EventSystem") == null)
        //{
        //    Instantiate(eventSystem);
        //}
        score = 0;
        isGameFinish = false;
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
        RecordManager.Instance.SaveScore(score);
    }

    public bool GetIsGameFinish()
    {
        return isGameFinish;
    }
}
