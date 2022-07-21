using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevelopersIntroView : View
{
    
    private PlayerInput _inputActions;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private AudioSource _audioIntro;
    [SerializeField]
    private View _nextView;
    [SerializeField]
    private Button _skipBtn;

    public override void Initialize()
    {
        _inputActions = new PlayerInput();
        _inputActions.UIInput.Confirm.performed += Context => Skip();
        _skipBtn.onClick.AddListener(() => Skip());
    }

    public override void Show(object parameter = null)
    {
        base.Show(parameter);
        _inputActions.Enable();
        StartCoroutine(OnStart());
        StartCoroutine(OnFinish());
    }

    private IEnumerator OnStart()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.LeanAlpha(0, 1);
        yield return new WaitForSeconds(0f);
        _audioIntro?.Play();
    }

    private IEnumerator OnFinish()
    {
        yield return new WaitForSeconds(_audioIntro.clip.length-1);
        _canvasGroup.LeanAlpha(1, 1);
        yield return new WaitForSeconds(2);
        ViewManager.Show(_nextView);
    }



    private void Skip()
    {
        Debug.Log("Skiped");
        StopCoroutine(OnStart());
        StopCoroutine(OnFinish());
        _audioIntro?.Stop();
        ViewManager.Show(_nextView);
    }

    public override void Hide()
    {
        base.Hide();
        _inputActions.Disable();
    }
}
