using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTitleSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("�^�C�g����");
        SceneManager.Instance.Change("Title");
    }
}
