using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuView : View
{
    [SerializeField]
    private Button _continueBtn;
    [SerializeField]
    private Button _menuBtn;
    public override void Initialize()
    {
        _continueBtn.onClick.AddListener(() =>
        {
            PauseManager.instance.Pause();
        });

        _menuBtn.onClick.AddListener(() => { SceneManager.LoadScene("MainMenu"); });
    }

}
