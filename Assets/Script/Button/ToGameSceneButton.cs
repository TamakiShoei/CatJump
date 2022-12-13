using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGameSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.Instance.Change("Game");
    }
}
