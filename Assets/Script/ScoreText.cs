using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeReference]
    public GameObject obj = null;

    private int score = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        Text text = obj.GetComponent<Text>();

        score = GameManager.Instance.GetScore();
        text.text = "ScoreÅF" + score;
    }
}
