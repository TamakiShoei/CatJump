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
        StartCoroutine(GetTopThreeUserDatasContinue());
    }

    private IEnumerator GetTopThreeUserDatasContinue()
    {
        var topThreeData = FirebaseDatabaseManager.Instance.GetTopThreeData();

        yield return StartCoroutine(topThreeData);

        var datas = (List<UserPlayData>)topThreeData.Current;

        for (int i = 0; i < datas.Count; i++)
        {
            if (datas[i] != null)
            {
                string tmpName = datas[i].username;
                int tmpScore = datas[i].score;
                string inputStr = tmpName + "F" + tmpScore;
                text[i].GetComponent<Text>().text = inputStr;
            }
            else if (datas[i] == null)
            {
                text[i].GetComponent<Text>().text = (i + 1) + "‹L˜^‚È‚µ";
            }
        }
    }
}
