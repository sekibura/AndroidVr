using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnScreenMessageScript : MonoBehaviour
{

    [Header("Inspect Screen Not VR")]
    [SerializeField]
    private GameObject _inspectScreen;
    [SerializeField]
    private TMP_Text _inspectScreenText;

    [Header("Inspect Screen VR")]
    [SerializeField]
    private GameObject _inspectScreenVR;
    [SerializeField]
    private TMP_Text _inspectScreenTextVR;

    private void Start()
    {
        CloseMessage();
    }

    public void ShowMessage(string message)
    {
        if (SetupInitialization.instance.IsVR)
        {
            _inspectScreenVR.SetActive(true);
            _inspectScreenTextVR.text = message;
        }
        else
        {
            _inspectScreen.SetActive(true);
            _inspectScreenText.text = message;
        }
        
    }

    public void CloseMessage()
    {
        _inspectScreenText.text = "";
        _inspectScreenTextVR.text = "";
        _inspectScreen.SetActive(false);
        _inspectScreenVR.SetActive(false);
    }
}
