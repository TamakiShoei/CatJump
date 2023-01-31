using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToResultSceneButton : MonoBehaviour
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
        SceneManager.Instance.Change("Record");
    }
}
