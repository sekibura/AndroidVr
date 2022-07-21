using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadingManager : MonoBehaviour
{
    public static ShadingManager instance = null; 
    CanvasGroup _canvasGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Init();
    }

    private void Init()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShadeIn(float duration , Action doAfter = null, float waitSeconds = 0)
    {
        StartCoroutine(Shading(0, 1, duration, doAfter, waitSeconds));
    }

    public void ShadeOut(float duration, Action doAfter = null, float waitSeconds = 0)
    {
        StartCoroutine(Shading(1, 0, duration, doAfter, waitSeconds));
    }

    public void SetAlpha(float alpha)
    {
        _canvasGroup.alpha = alpha;
    }



    private IEnumerator Shading(float startAlpha, float finishAlpha, float duration, Action doAfter = null, float waitSeconds = 0)
    {
        _canvasGroup.alpha = startAlpha;
        _canvasGroup.LeanAlpha(finishAlpha, duration);
        yield return new WaitForSecondsRealtime(duration + waitSeconds);
        UnityMainThreadDispatcher.Instance().Enqueue(() => { doAfter?.Invoke(); });
    }
}
