using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNameCanvas : MonoBehaviour
{
    private void Start()
    {
        //this.gameObject.SetActive(false);
        //if (FireBaseAuthManager.Instance.CheckFirstLogin() == true)
        //{
        //    this.gameObject.SetActive(true);
        //}
        //else
        //{
        //    this.gameObject.SetActive(true);
        //    //Destroy(this.gameObject);
        //}
        FireBaseAuthManager.Instance.Initialize();
    }
}
