using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    [SerializeField]
    private Text[] text;

    public void Start()
    {
        List<UserPlayData> data;
        data = FirebaseDatabaseManager.Instance.GetTopThreeData();
        //Debug.Log(data.Length);
        //for (int i = 0; i < data.Length; i++) 
        //{
        //    if (data[i] != null)
        //    {
        //        string tmpName = data[i].username;
        //        int tmpScore = data[i].score;
        //        //Debug.Log(tmpName);
        //        //Debug.Log(tmpScore);
        //        string inputStr = tmpName + "F" + tmpScore;
        //        text[i].GetComponent<Text>().text = inputStr;
        //    }
        //}
    }
}
