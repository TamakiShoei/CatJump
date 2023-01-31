using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    AudioClip jumpSE;

    SoundManager soundManager;
    private float gravity = 1.0f;
    
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        transform.position = new Vector3(-7.0f, 3.3f, 0.0f);
    }

    void Update()
    {
        //デバッグ用スペースキー
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 4)
        {
            gravity = 0;
            gravity += 8.0f;
            soundManager.PlaySe(jumpSE);
        }

        //スマホタッチ用
        if (Input.GetMouseButtonDown(0) && transform.position.y < 4)
        {
            gravity = 0;
            gravity += 8.0f;
            soundManager.PlaySe(jumpSE);
        }

        if (transform.position.y < -6.0f)
        {
            GameManager.Instance.GameFinished();
            Destroy(this.gameObject);
            SceneManager.Instance.Change("Result");
        }

        transform.Translate(0.0f, gravity * Time.deltaTime, 0.0f);
        gravity -= 0.2f;

    }
}
