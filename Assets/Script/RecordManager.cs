using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : SingletonMonoBehaviour<RecordManager>
{
    private string inputName;
    private int inputScore;

    //ï€ë∂èàóù
    public void SaveScore(int score)
    {
        inputScore = score;
        UserPlayData data = new UserPlayData(inputName, inputScore);
        FirebaseDatabaseManager.Instance.SaveUserData(data);
    }

    public void SetName(string set_name)
    {
        inputName = set_name;
    }
}
