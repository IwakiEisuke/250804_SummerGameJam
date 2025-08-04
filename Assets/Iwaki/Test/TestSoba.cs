using UnityEngine;

public class TestSoba : SobaBase
{
    [SerializeField] float speed = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform bottomTransform;

    void Update()
    {
        if (IsSlurping)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
    }

    protected override void Failure()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1f);
        Destroy(this);
    }

    public override Transform GetBottom()
    {
        return bottomTransform;
    }
}

public abstract class SobaBase : MonoBehaviour
{
    /// <summary>
    /// すすり中か
    /// </summary>
    private bool _isSlurping;

    public bool IsSlurping => _isSlurping;

    public abstract Transform GetBottom();

    /// <summary>
    /// すすり開始
    /// </summary>
    /// <param name="logic"></param>
    public void StartSlurp(SobaGameLogic logic)
    {
        if (_isSlurping)
        {
            Debug.LogWarning("Already slurping!");
            return;
        }

        _isSlurping = true;

        // 成功・失敗時のアクションを登録
        logic.SuccessAction += Success;
        logic.FailureAction += Failure;
        logic.OverSlurpAction += OverSlurp;
        // すすり状態をキャンセルするためのアクションを登録
        logic.SuccessAction += CancelSlurp;
        logic.FailureAction += CancelSlurp;
        logic.OverSlurpAction += CancelSlurp;
    }

    /// <summary>
    /// すすり状態を解除
    /// </summary>
    void CancelSlurp()
    {
        _isSlurping = false;
    }

    /// <summary>
    /// 成功判定時の処理
    /// </summary>
    protected virtual void Success()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 失敗判定時の処理
    /// </summary>
    protected virtual void Failure()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// すすりすぎた場合の処理
    /// </summary>
    protected virtual void OverSlurp()
    {
        Destroy(gameObject);
    }
}