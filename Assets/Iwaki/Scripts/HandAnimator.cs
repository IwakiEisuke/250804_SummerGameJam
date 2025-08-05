using DG.Tweening;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    [SerializeField] Transform _handTransform;
    [SerializeField] Transform _lower;
    [SerializeField] Transform _upper;
    [SerializeField] float _tweenDuration;
    [SerializeField] Ease _tweenEase = Ease.Linear;

    private void Start()
    {
        _handTransform.position = _lower.position;
        _handTransform.rotation = _lower.rotation;
    }

    private void HandMove(Transform target)
    {
        _handTransform.DOMove(target.position, _tweenDuration).SetEase(_tweenEase);
        _handTransform.DORotate(target.rotation.eulerAngles, _tweenDuration).SetEase(_tweenEase);
    }

    [ContextMenu("Raise Hand")]
    public void RaiseHand()
    {
        HandMove(_upper);
    }

    [ContextMenu("Lower Hand")]
    public void LowerHand()
    {
        HandMove(_lower);
    }
}
