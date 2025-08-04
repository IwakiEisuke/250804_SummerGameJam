using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SobaGameLogic : MonoBehaviour
{
    [SerializeField] InputActionReference _button;
    [SerializeField] SobaGenerator _generator;
    [SerializeField] float _successFrameCount = 3f; // 成功判定のフレーム数(60fps)

    // システム系
    [SerializeField] UnityEvent _onSuccess;
    [SerializeField] UnityEvent _onFailure;

    // そば側
    public event Action SuccessAction;
    public event Action FailureAction;
    public event Action OverSlurpAction;

    bool _isInSuccessArea = false;
    bool _isSlurping = false;

    float _overSlurpTimer = 0f; // すすりすぎと判定するまでの時間を計測するタイマー

    SobaBase _currentSoba;

    void Start()
    {
        _button.action.performed += Performed;
        _button.action.canceled += Cancelled;
        _currentSoba = SpawnSoba(); // ゲーム開始時にそばを生成
    }

    private SobaBase SpawnSoba()
    {
        return _generator.SpawnSoba().GetComponent<SobaBase>();
    }

    private void OnTriggerExit(Collider other)
    {
        _isInSuccessArea = true;
    }

    private void Update()
    {
        if (_isInSuccessArea)
        {
            _overSlurpTimer += Time.deltaTime;
            if (_overSlurpTimer >= _successFrameCount / 60f) // フレーム数を秒に変換(60fps想定)
            {
                OverSlurp();
                _overSlurpTimer = 0f;
            }
        }
    }

    private bool CheckSuccess()
    {
        return _isInSuccessArea;
    }

    private void Performed(InputAction.CallbackContext ctx)
    {
        if (_currentSoba != null)
        {
            _currentSoba.StartSlurp(this);
            _isSlurping = true;
        }
    }

    private void Cancelled(InputAction.CallbackContext ctx)
    {
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
        _onSuccess.Invoke();
        SuccessAction?.Invoke();
        Next();
    }

    private void Failure()
    {
        Debug.Log("Failure");
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

    private void Next()
    {
        _isSlurping = false;
        _isInSuccessArea = false;
        SuccessAction = null;
        FailureAction = null;
        OverSlurpAction = null;
        _currentSoba = SpawnSoba();
    }

    private void OnDestroy()
    {
        _button.action.performed -= Performed;
        _button.action.canceled -= Cancelled;
    }
}
