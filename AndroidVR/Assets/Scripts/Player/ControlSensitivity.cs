using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlSensitivity : MonoBehaviour
{
    public static ControlSensitivity instance = null; // Экземпляр объекта

    [SerializeField]
    private float _mouseSens;
    [SerializeField]
    private float _gamePadSens;
    [SerializeField]
    private float _touchScreenSens;

    public float MouseLookSensitivity => _mouseSens;
    public float GamepadLookSensitivity => _gamePadSens;
    public float TouchpadLookSensitivity => _touchScreenSens;

    //public float MouseLookSensitivity { get; set; }
    //public float GamepadLookSensitivity { get; set; }
    //public float TouchpadLookSensitivity { get; set; }

    private PlayerInput _inputs;

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
        _inputs = new PlayerInput();
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    public float GetLookSensitivity()
    {
        var a = _inputs.Player.FPSView.activeControl;
        if (a == null)
        {

            return 0f;

        }
        //Debug.Log(a.device.name);
        switch (a.device.name)
        {

            case "Mouse":
            {
                    //Debug.Log("Mouse");
                    return MouseLookSensitivity;
            }

            case "XInputControllerWindows":
            {
                    //Debug.Log("XInputControllerWindows");
                    return GamepadLookSensitivity;
            }

            case "Gamepad":
            {
                    //Debug.Log("Gamepad");
                    return TouchpadLookSensitivity;
            }

            default:
                return 0f;
        }

    }
    private void Update()
    {
        //Debug.Log();
    }
}


