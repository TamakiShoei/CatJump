using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    [SerializeField]
    private Text[] text;


    public void Start()
    {
        StartCoroutine(GetTopThreeUserDatasCoroutine());
    }

    private IEnumerator GetTopThreeUserDatasCoroutine()
    {
        var getTopThreeData = FirebaseDatabaseManager.Instance.GetTopThreeData();
        // getTopThreeDataのコルーチンを走らせて、coroutineが終われば23行目以降に処理が通る
        yield return StartCoroutine(getTopThreeData);
        // List<UserPlayData>にgetTopThreeDataのyield return outDataの内容をキャスト
        var datas = (List<UserPlayData>)getTopThreeData.Current;

        for (int i = 0; i < datas.Count; i++)
        {
            if (datas[i] != null)
            {
                string tmpName = datas[i].username;
                int tmpScore = datas[i].score;
                //Debug.Log(tmpName);
                //Debug.Log(tmpScore);
                string inputStr = tmpName + "：" + tmpScore;
                text[i].GetComponent<Text>().text = inputStr;
            }
        }
    }

}
