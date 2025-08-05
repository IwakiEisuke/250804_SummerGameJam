using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SobaGameLogic : MonoBehaviour
{
    [SerializeField] InputActionReference _button;
    [SerializeField] SobaGenerator _generator;
    [SerializeField] float _successAreaHeight = 0.5f; // 成功判定の高さ(そばの底からの距離)
    [SerializeField] Transform _referencePoint;

    // システム系
    [SerializeField] UnityEvent _onSuccess;
    [SerializeField] UnityEvent _onFailure;

    // アニメーション
    [SerializeField] UnityEvent _onSlurpStart;
    [SerializeField] UnityEvent _onSlurpEnd;

    // そば側
    public event Action SuccessAction;
    public event Action FailureAction;
    public event Action OverSlurpAction;

    bool _isInSuccessArea = false;
    bool _isSlurping = false;
    bool _isGameStop = true;

    SobaBase _currentSoba;
    Transform _currentSobaBottom;

    void Start()
    {
        _button.action.performed += Performed;
        _button.action.canceled += Cancelled;
        _currentSoba = SpawnSoba(); // ゲーム開始時にそばを生成
    }

    private SobaBase SpawnSoba()
    {
        var soba = _generator.SpawnSoba().GetComponent<SobaBase>();
        _currentSobaBottom = soba.GetBottom();
        return soba;
    }

    private void Update()
    {
        if (_isSlurping)
        {
            // 成功エリアに入ったか
            if (_successAreaHeight > Mathf.Abs(_referencePoint.position.y - _currentSobaBottom.position.y))
            {
                _isInSuccessArea = true;
            }
            else
            {
                // 成功エリアに一度入ったあと外れたら失敗
                if (_isInSuccessArea)
                {
                    OverSlurp();
                }
                _isInSuccessArea = false;
            }
        }
    }

    private bool CheckSuccess()
    {
        return _isInSuccessArea;
    }

    private void Performed(InputAction.CallbackContext ctx)
    {
        if (_isGameStop)
            return;

        _onSlurpStart.Invoke();

        if (_currentSoba != null)
        {
            _currentSoba.StartSlurp(this);
            SoundManager.Instance.PlaySE(SESoundData.SE.SobaSip);
            _isSlurping = true;
        }
    }

    private void Cancelled(InputAction.CallbackContext ctx)
    {
        // ゲーム終了後も閉じれる
        _onSlurpEnd.Invoke();

        if (_isGameStop)
            return;

        if (_isSlurping)
        {
            if (CheckSuccess())
            {
                Success();
            }
            else
            {
                Failure();
            }
        }
    }

    private void Success()
    {
        Debug.Log("Success");
        SoundManager.Instance.PlaySE(SESoundData.SE.SobaSuccess);
        _onSuccess.Invoke();
        SuccessAction?.Invoke();
        Next();
    }

    private void Failure()
    {
        Debug.Log("Failure");
        SoundManager.Instance.PlaySE(SESoundData.SE.SobaFaile);
        _onFailure.Invoke();
        FailureAction?.Invoke();
        Next();
    }

    private void OverSlurp()
    {
        Debug.Log("OverSlurp");
        _onFailure.Invoke();
        OverSlurpAction?.Invoke();
        Next();
    }

    // 次の蕎麦の準備
    private void Next()
    {
        _isSlurping = false;
        _isInSuccessArea = false;
        SuccessAction = null;
        FailureAction = null;
        OverSlurpAction = null;
        _currentSoba = SpawnSoba();
    }

    public void StartGame()
    {
        _isGameStop = false;
    }

    public void StopGame()
    {
        _isGameStop = true;
    }

    private void OnDestroy()
    {
        _button.action.performed -= Performed;
        _button.action.canceled -= Cancelled;
    }

    private void OnDrawGizmos()
    {
        if (_referencePoint == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_referencePoint.position, new Vector3(0.1f, _successAreaHeight * 2, 0.0f));
    }
}
