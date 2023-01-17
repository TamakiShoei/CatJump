using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int score;

    private void Start()
    {
        score = GameManager.Instance.GetScore();
        text.text = score.ToString();
    }
}
