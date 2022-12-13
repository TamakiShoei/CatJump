using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNameField : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Transform InputNameCanvas;


    public void InputText()
    {
        RecordManager.Instance.SetName(inputField.text);
        Destroy(InputNameCanvas.gameObject);
    }
}
