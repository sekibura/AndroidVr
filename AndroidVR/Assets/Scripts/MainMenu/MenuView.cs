using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuView : View
{
    #region private fields
    private PlayerInput _inputActions;
    #endregion

    [Header("Buttons")]
    [SerializeField]
    private Button _loadBtn;
    [SerializeField]
    private Button _newGameBtn;
    [SerializeField]
    private Button _settingsBtn;
    [SerializeField]
    private Button _exitBtn;
    [SerializeField]
    private Button _vkBtn;
    [SerializeField]
    private Button _pressStartBtn;
    [SerializeField]
    private Button _startGameBtn;

    [Header("AudioSources")]
    [SerializeField]
    private AudioSource _menuTheme;

    [Header("Gameobjects")]
    [SerializeField]
    private GameObject _pressStart;
    [SerializeField]
    private GameObject _menu;

    public override void Initialize()
    {
        ButtonInit();
        _menu.SetActive(false);
        _pressStart.SetActive(true);
    }

    private void ButtonInit()
    {
        _inputActions = new PlayerInput();
        _inputActions.UIInput.Confirm.performed += ShowMenu;

        _settingsBtn.onClick.AddListener(()=>ViewManager.Show<SettingsMainMenuView>());
        _exitBtn.onClick.AddListener(() => Application.Quit());
        _vkBtn.onClick.AddListener(() => Application.OpenURL("https://vk.com/silentvenice"));
        _pressStartBtn.onClick.AddListener(() => ShowMenu(new InputAction.CallbackContext()));
        _startGameBtn.onClick.AddListener(()=>StartGame());
    }

    private void StartGame()
    {        
        #if PLATFORM_ANDROID && !UNITY_EDITOR
        ViewManager.Show<PlayModeView>();
        #else
        SetupInitialization.instance.IsVR = false;
        ShadingManager.instance.ShadeIn(1, () => { SceneManager.LoadScene("Room"); }, 1);
                
        #endif
    }

    private void ShowMenu(InputAction.CallbackContext obj)
    {
        Debug.Log("Show menu");
        if (!_menu.activeSelf)
        {
            _pressStart.SetActive(false);
            _menu.SetActive(true);
            _inputActions.UIInput.Confirm.performed -= ShowMenu;
        }
            
    }

    public override void Show(object parameter = null)
    {
        base.Show(parameter);
        if (!_menuTheme.isPlaying)
            _menuTheme.Play();
        _inputActions.Enable();
    }

    public override void Hide()
    {
        base.Hide();
        _inputActions.Disable();
    }
}
