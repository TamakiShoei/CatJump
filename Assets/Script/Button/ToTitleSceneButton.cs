using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTitleSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("タイトルへ");
        SceneManager.Instance.Change("Title");
    }
}
