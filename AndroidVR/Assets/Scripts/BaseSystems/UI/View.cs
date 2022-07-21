using UnityEngine;
using UnityEngine.EventSystems;

public abstract class View : MonoBehaviour
{
    [Header("Select UI Element")]
    [SerializeField]
    private GameObject _firstSelectedButton;
    [SerializeField]
    private bool _toSelect;
    public abstract void Initialize();
    public virtual void Hide() => gameObject.SetActive(false);
    public virtual void Show(object parameter = null)
    {
        gameObject.SetActive(true);
        if(_firstSelectedButton!=null && _toSelect)
        {
            EventSystem.current.SetSelectedGameObject(_firstSelectedButton);
            Debug.Log($"Selected button is {_firstSelectedButton.name}");
        }
            
    }
}