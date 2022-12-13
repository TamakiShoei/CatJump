using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToResultSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("test");
        SceneManager.Instance.Change("Record");
    }
}
