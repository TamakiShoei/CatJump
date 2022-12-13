using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTitleSceneButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("ƒ^ƒCƒgƒ‹‚Ö");
        SceneManager.Instance.Change("Title");
    }
}
