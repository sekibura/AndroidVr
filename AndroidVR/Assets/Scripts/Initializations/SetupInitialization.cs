using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInitialization : MonoBehaviour
{
    public static SetupInitialization instance = null; // Экземпляр объекта

    [SerializeField]
    private  bool _isVR;
    private bool _isMobile = true;
    public bool IsVR => _isVR;
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
_isVR = false;
_isMobile = false;
#endif

        Debug.Log("vr= " + _isVR + "|mobile=" + IsMobile);


    }   
}
