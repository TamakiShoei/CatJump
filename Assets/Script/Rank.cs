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
        // getTopThreeData�̃R���[�`���𑖂点�āAcoroutine���I����23�s�ڈȍ~�ɏ������ʂ�
        yield return StartCoroutine(getTopThreeData);
        // List<UserPlayData>��getTopThreeData��yield return outData�̓��e���L���X�g
        var datas = (List<UserPlayData>)getTopThreeData.Current;

        for (int i = 0; i < datas.Count; i++)
        {
            if (datas[i] != null)
            {
                string tmpName = datas[i].username;
                int tmpScore = datas[i].score;
                //Debug.Log(tmpName);
                //Debug.Log(tmpScore);
                string inputStr = tmpName + "�F" + tmpScore;
                text[i].GetComponent<Text>().text = inputStr;
            }
        }
    }

}
