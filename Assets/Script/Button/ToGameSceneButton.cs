using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGameSceneButton : MonoBehaviour
{
    [SerializeField]
    AudioClip MyaoSE;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();   
    }

    public void OnClick()
    {
        soundManager.PlaySe(MyaoSE);
        GameManager.Instance.Initialize();
        SceneManager.Instance.Change("Game");
    }
}
