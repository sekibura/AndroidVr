using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance = null;
    private PlayerInput _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInput();
        _inputActions.UIInput.Pause.performed += Context => Pause();

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

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Pause()
    {
        Debug.Log("Pause");
        if(GameStateManager.instance.CurrentGameState == GameState.GamePlay)
        {
            GameStateManager.instance.SetState(GameState.Paused);
            if (SetupInitialization.instance.IsVR)
                ViewManager.Show<PauseMenuVRView>();
            else
                ViewManager.Show<PauseMenuView>();
            Cursor.visible = true;
        }
        else
        {
            GameStateManager.instance.SetState(GameState.GamePlay);
            ViewManager.ShowLast();
            Cursor.visible = false;
        }
       
    }
}
