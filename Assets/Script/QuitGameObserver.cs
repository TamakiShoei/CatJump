using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameObserver : SingletonMonoBehaviour<QuitGameObserver>
{
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("PlayerName");
    }
}
