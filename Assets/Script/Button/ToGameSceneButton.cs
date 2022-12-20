using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGameSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.Initialize();
        SceneManager.Instance.Change("Game");
    }
}
