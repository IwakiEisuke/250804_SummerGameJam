using DG.Tweening;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] Transform _handTransform;
    [SerializeField] Transform _lower;
    [SerializeField] Transform _upper;
    [SerializeField] float _raiseTweenDuration;
    [SerializeField] Ease _raiseTweenEase = Ease.Linear;
    [SerializeField] float _lowerTweenDuration;
    [SerializeField] Ease _lowerTweenEase = Ease.Linear;

    private void Start()
    {
        _handTransform.position = _lower.position;
        _handTransform.rotation = _lower.rotation;
    }

    private void HandMove(Transform target, float duration, Ease ease)
    {
        _handTransform.DOMove(target.position, duration).SetEase(ease);
        _handTransform.DORotate(target.rotation.eulerAngles, duration).SetEase(ease);
    }

    [ContextMenu("Raise Hand")]
    public void RaiseHand()
    {
        HandMove(_upper, _raiseTweenDuration, _raiseTweenEase);
    }

    [ContextMenu("Lower Hand")]
    public void LowerHand()
    {
        HandMove(_lower, _lowerTweenDuration, _lowerTweenEase);
    }
}
