using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlsInit : MonoBehaviour
{
    [SerializeField]
    private GameObject _controlElements;
    void Start()
    {
        Debug.Log(SetupInitialization.instance.IsVR + " " + !SetupInitialization.instance.IsMobile);
        if(SetupInitialization.instance.IsVR || !SetupInitialization.instance.IsMobile)
        {
            Debug.Log("set false");
            _controlElements.SetActive(false);
        }

    }
}
