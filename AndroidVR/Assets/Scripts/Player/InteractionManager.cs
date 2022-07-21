using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// для объектов которые не требуют отклика со стороны игрока, по типу дверей. То есть нажали, а дальше объект сам обрабатывает.
public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private float distance;
    private IInteractable _interactable;
    private PlayerInput _inputActions;
    int i = 0;

    private void Awake()
    {
        _inputActions = new PlayerInput();
        _inputActions.Player.Interaction.performed += Context => { Performed(); };
    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    //private void Update()
    //{
    //    Vector3 forward = transform.TransformDirection(Vector3.forward);
    //    RaycastHit hit;
    //    Debug.DrawRay(transform.position, forward * distance, Color.red);

    //    if (Physics.Raycast(transform.position, forward, out hit, distance))
    //    {
    //        if(_inputActions.Player.Interaction.ReadValue<float>() > 0.1f)
    //        {
    //            Debug.Log("Interaction");
    //            _interactable = hit.transform.gameObject.GetComponent<IInteractable>();
    //            if (_interactable != null)
    //            {
    //                Debug.Log("Interaction in if");
    //                _interactable.OnInteract();
    //            }
    //        }
            

           
    //    }

    
    //}

    private void Performed()
    {
        
        Debug.Log("Click "+i);
        i++;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, forward * distance, Color.red);

        if (Physics.Raycast(transform.position, forward, out hit, distance))
        {
            if (_inputActions.Player.Interaction.ReadValue<float>() > 0.1f)
            {
                Debug.Log("Interaction");
                _interactable = hit.transform.gameObject.GetComponent<IInteractable>();
                if (_interactable != null)
                {
                    Debug.Log("Interaction in if");
                    _interactable.OnInteract();
                }
            }



        }
    }

}
