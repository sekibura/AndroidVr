using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayModeView : View
{
    [Header("Buttons")]
    [SerializeField]
    private Button _touchScreenModeBtn;
    [SerializeField]
    private Button _vrModeBtn;
    public override void Initialize()
    {
        _touchScreenModeBtn.onClick.AddListener(() => StartGame(false));
        _vrModeBtn.onClick.AddListener(() => StartGame(true));
    }

    private void StartGame(bool isVR)
    {
        
        SetupInitialization.instance.IsVR = isVR;
        ShadingManager.instance.ShadeIn(1, () => { SceneManager.LoadScene("Room"); }, 1);
    }

   
}
