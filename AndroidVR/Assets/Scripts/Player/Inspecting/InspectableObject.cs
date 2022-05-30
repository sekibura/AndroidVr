using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectableObject : MonoBehaviour
{
    [SerializeField]
    private string _message;

    public string Message
    {
        get { return _message; }
        private set { _message = value; }
    }


    public void DoSmth()
    {

    }
}
