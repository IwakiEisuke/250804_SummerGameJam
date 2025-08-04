using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeCanvasGroup;

    public UnityEvent onFadeInComplete;
    public UnityEvent onFadeOutComplete;

    private void Start()
    {
        _fadeCanvasGroup.alpha = 1.0f;
        FadeIn();
    }

    /// <summary>
    /// フェードインの関数
    /// </summary>
    /// <param name="duration">完了時間</param>

    public void FadeIn(float duration = 3)
    {
        _fadeCanvasGroup.DOFade(0f, duration).SetEase(Ease.InOutQuad)
            .OnComplete(() => onFadeInComplete.Invoke());
    }

    /// <summary>
    /// フェードアウトの関数
    /// </summary>
    /// <param name="duration">完了時間</param>
    public void FadeOut(float duration)
    {
        _fadeCanvasGroup.DOFade(1f, duration).SetEase(Ease.InOutQuad)
            .OnComplete(() => onFadeOutComplete.Invoke());
    }
}
