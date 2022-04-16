using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInitialization : MonoBehaviour
{
    public static SetupInitialization instance = null; // ��������� �������

    [SerializeField]
    private  bool _isVR;
    public bool IsVR => _isVR;

    private void Awake()
    {
#if !PLATFORM_ANDROID && !UNITY_ANDROID
_isVR = false;
#endif
    }


    // �����, ����������� ��� ������ ����
    void Start()
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
    }

   
}
