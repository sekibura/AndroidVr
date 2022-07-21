using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMainMenuView : View
{
    #region private fields
    private PlayerInput _inputActions;
    #endregion

    [Header("Buttons")]
    [SerializeField]
    private Button _backBtn;


    public override void Initialize()
    {
        ButtonsInit();
        InputInit();
    }

    private void ButtonsInit()
    {
        _backBtn.onClick.AddListener(() => ViewManager.ShowLast());
    }

    private void InputInit()
    {
        _inputActions = new PlayerInput();
        _inputActions.UIInput.Pause.performed += Context => ViewManager.ShowLast();
    }



    public override void Show(object parameter = null)
    {
        base.Show(parameter);
        _inputActions.Enable();
    }

    public override void Hide()
    {
        base.Hide();
        _inputActions.Disable();
    }


}
