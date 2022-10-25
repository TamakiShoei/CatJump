using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obj;

    private float timeCounter = 0;
    void Start()
    {
 
    }

    void Update()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] == null)
            {
                return;
            }
        }
        if (timeCounter >= 1.5)
        {
            Instantiate(obj[0], new Vector3(9.3f, 0.0f, 0.0f), Quaternion.identity);
            timeCounter = 0;
        }
        timeCounter += Time.deltaTime;
    }
}
