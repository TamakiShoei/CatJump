using System.Collections;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private int score;
    private bool isGameFinish;

    public void Initialize()
    {
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
    }

    public bool GetIsGameFinish()
    {
        return isGameFinish;
    }
}
