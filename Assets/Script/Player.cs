using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float gravity = 1.0f;
    
    void Start()
    {
        transform.position = new Vector3(-7.0f, 3.3f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravity = 0;
            gravity += 5.0f;
        }

        transform.Translate(0.0f, gravity * Time.deltaTime, 0.0f);
        gravity -= 0.05f;
        
    }
}
