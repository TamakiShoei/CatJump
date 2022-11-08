using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScoreCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("’Ê‚è”²‚¯¬Œ÷");
        }
    }
}
