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
    [SerializeField]
    private Text EmptyErrorText;
    [SerializeField]
    private Text OverErrorText;

    private void Start()
    {
        if (PlayerPrefs.GetString("PlayerName", "NothingName") != "NothingName")
        {
            Destroy(InputNameCanvas.gameObject);
        }
    }
    public void InputText()
    {
        EmptyErrorText.gameObject.SetActive(false);
        OverErrorText.gameObject.SetActive(false);

        if (inputField.text.Length <= 0)
        {
            EmptyErrorText.gameObject.SetActive(true);
            return;
        }
        else if (inputField.text.Length > 8)
        {
            OverErrorText.gameObject.SetActive(true);
            return;
        }

        RecordManager.Instance.SetName(inputField.text);
        PlayerPrefs.SetString("PlayerName", inputField.text);
        Destroy(InputNameCanvas.gameObject);
    }
}
