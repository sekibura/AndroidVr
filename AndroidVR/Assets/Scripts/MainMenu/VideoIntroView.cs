
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoIntroView : View
{
    private PlayerInput _inputActions;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private VideoPlayer _videoIntro;
    [SerializeField]
    private View _nextView;
    [SerializeField]
    private Button _skipBtn;

    public override void Initialize()
    {
        _inputActions = new PlayerInput();
        _inputActions.UIInput.Confirm.performed += Context => { Skip(); };
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
        _videoIntro?.Play();
        _canvasGroup.alpha = 1f;
        
        yield return new WaitForSeconds(1f);
        _canvasGroup.LeanAlpha(0, 1);
    }

    private IEnumerator OnFinish()
    {
        yield return new WaitForSeconds((float)_videoIntro.clip.length);
        _canvasGroup.LeanAlpha(1, 2);
        yield return new WaitForSeconds(2);
        ViewManager.Show(_nextView);
    }

    private void Skip()
    {
        Debug.Log("Skiped");
        StopCoroutine(OnStart());
        StopCoroutine(OnFinish());
        _videoIntro?.Stop();
        ViewManager.Show(_nextView);
    }

    public override void Hide()
    {
        base.Hide();
        _inputActions.Disable();
    }
}
