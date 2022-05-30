using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChestDoor :MonoBehaviour, IInteractable
{
    
    //public bool IsMultiple => _isMultiple;
    public bool IsInteractable => _isInteractable;
    [Header("Interactable")]
    //[SerializeField]
    //private bool _isMultiple;
    [SerializeField]
    private bool _isInteractable;

//    [Header("DoorElements")]
    private Animator _animator;
    private DoorState _doorState=DoorState.Close;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        Debug.Log("OnInteract");
        if(_doorState== DoorState.Open)
        {
            _animator.Play("Close");
            _doorState = DoorState.Close;
        }
        else
        {
            _animator.Play("Open");
            _doorState = DoorState.Open;
        }


    }

    enum DoorState
    {
        Open, Close
    }
 
}
