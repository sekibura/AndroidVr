using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInitialization : MonoBehaviour
{
    public static SetupInitialization instance = null; // Экземпляр объекта

    //[SerializeField]
    //private  bool _isVR;
    private bool _isMobile = true;
    //public bool IsVR => _isVR;
    public bool IsVR { get; set; }
    public int MyProperty { get; set; }
    public bool IsMobile => _isMobile;

    //public event Action OnVREnable;
    //public event Action OnVRDisable;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        #if !PLATFORM_ANDROID || !UNITY_ANDROID || UNITY_EDITOR
        IsVR = false;
        _isMobile = false;
        Debug.Log("isVR falsed");
        #endif

        Debug.Log("vr= " + IsVR + "|mobile=" + IsMobile);


    }   
}
