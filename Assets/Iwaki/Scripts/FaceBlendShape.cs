using DG.Tweening;
using UnityEngine;

public class FaceBlendShape : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] float _blendDuration = 0.5f;
    [SerializeField] Ease _blendEase = Ease.InOutQuad;

    private void SetBlendShapeWeight(int index, float weight)
    {
        if (_skinnedMeshRenderer != null && index >= 0 && index < _skinnedMeshRenderer.sharedMesh.blendShapeCount)
        {
            DOTween.To(() => _skinnedMeshRenderer.GetBlendShapeWeight(index), 
                value => _skinnedMeshRenderer.SetBlendShapeWeight(index, value), 
                weight, _blendDuration).SetEase(_blendEase);
        }
        else
        {
            Debug.LogWarning("Invalid blend shape index or SkinnedMeshRenderer is not assigned.");
        }
    }

    [ContextMenu("Open Mouth")]
    public void OpenMouth()
    {
        SetBlendShapeWeight(0, 100f);
    }

    [ContextMenu("Close Mouth")]
    public void CloseMouth()
    {
        SetBlendShapeWeight(0, 0f);
    }
}
