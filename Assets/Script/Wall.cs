using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Start()
    {
        transform.position = new Vector3(9.3f, 0.0f, 0.0f);
    }

    
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
