using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorText : MonoBehaviour
{
    [SerializeField]
    private Text errorText;

    private float alpha;

    private void Start()
    {
        alpha = 1;
        errorText.color = new Color(1, 0, 0, alpha);
    }

    private void Update()
    {
        alpha -= 0.7f * Time.deltaTime;
        errorText.color = new Color(1, 0, 0, alpha);

        if (alpha <= 0)
        {
            this.gameObject.SetActive(false);
            alpha = 1;
        }
    }
}
