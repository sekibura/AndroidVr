using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InspectManager : MonoBehaviour
{
    private PlayerInput _inputActions;
    public float distance;
    public Transform playerSocket;

    private Vector3 _originalPos;
    private bool _onInspect = false;
    private GameObject _inspected;

    [SerializeField]
    private FirstPersonController _fpsController;

    private InspectableObject _inspectableObject;
    

    //private bool _toInspect = false;

    private void Awake()
    {
        _inputActions = new PlayerInput();
        //_inputActions.Player.Interaction.started += context => { _toInspect = true; Debug.Log("interaction pressed");};
        //_inputActions.Player.Interaction.canceled += context => { _toInspect = false; Debug.Log("interaction pressed"); };

    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, forward*distance, Color.red);

        if (Physics.Raycast(transform.position, forward, out hit, distance))
        {
            //Debug.Log(hit.transform.gameObject.name);
            _inspectableObject = hit.transform.gameObject.GetComponent<InspectableObject>();

            if(_inspectableObject != null && !_onInspect)
            {
                //Debug.Log("1");
                
                if (_inputActions.Player.Interaction.ReadValue<float>() > 0.1f)
                {
                    //Debug.Log("2");
                    _inspected = hit.transform.gameObject;
                    _originalPos = hit.transform.position;
                    _onInspect = true;
                    StartCoroutine(PickUpItem(_inspectableObject));
                }
            }
        }

        if (_onInspect)
        {
            _inspected.transform.position = Vector3.Lerp(_inspected.transform.position, playerSocket.position, 0.2f);

            playerSocket.Rotate(new Vector3(_inputActions.Player.Move.ReadValue<Vector2>().y, -_inputActions.Player.Move.ReadValue<Vector2>().x,0) * Time.deltaTime * 125f);

        }
        else if (_inspected != null)
        {
            _inspected.transform.SetParent(null);
            _inspected.transform.position = Vector3.Lerp(_inspected.transform.position, _originalPos, 0.2f);
        }

        if ((_inputActions.Player.Cancel.ReadValue<float>() > 0.1f) && _onInspect)
        {
            StartCoroutine(DropItem());
            _onInspect = false;
        }
    }

    private IEnumerator PickUpItem(InspectableObject inspectableObject)
    {
        Debug.Log("PickUp");
        _fpsController.enabled = false;
        //_playerLookController.IsEnable = false;
        //_personMovementController.enabled = false;
        //_personMovementController.IsEnable = false;
        yield return new WaitForSeconds(0.2f);
        _inspected.transform.SetParent(playerSocket);
        inspectableObject.DoSmth();
    }

    private IEnumerator DropItem()
    {
        Debug.Log("Drop");
        _inspected.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(0.2f);
        _fpsController.enabled = true;
        //_personMovementController.enabled = true;
        //_playerLookController.IsEnable = true;
        //_personMovementController.IsEnable = false;
    }
}
