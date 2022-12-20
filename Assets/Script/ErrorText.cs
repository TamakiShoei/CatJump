using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorText : MonoBehaviour
{
    private float counter = 0;
    [SerializeField]
    private Text text;

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 5)
        {
            Destroy(this.gameObject);
        }
    }
}
