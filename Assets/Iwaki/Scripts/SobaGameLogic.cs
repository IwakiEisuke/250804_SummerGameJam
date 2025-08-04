using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SobaGameLogic : MonoBehaviour
{
    [SerializeField] InputActionReference _button;
    // システム系
    [SerializeField] UnityEvent _onSuccess;
    [SerializeField] UnityEvent _onFailure;

    // そば側
    public event Action successAction;
    public event Action failureAction;
    public event Action overSlurpAction;

    bool _isInSuccessArea = false;
    bool _isSlurping = false;

    void Start()
    {
        _button.action.performed += Performed;
        _button.action.canceled += Cancelled;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isInSuccessArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isInSuccessArea = false;
        // 通り過ぎたら失敗
        OverSlurp();
    }

    private bool CheckSuccess()
    {
        if (_isInSuccessArea)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Failure");
        }

        return _isInSuccessArea;
    }

    private void Performed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Pressed");
        var soba = FindAnyObjectByType<SobaBase>();
        if (soba != null)
        {
            soba.StartSlurp(this);
            _isSlurping = true;
        }
    }

    private void Cancelled(InputAction.CallbackContext ctx)
    {
        Debug.Log("Released");

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
        _onSuccess.Invoke();
        successAction?.Invoke();
        CancelActions();
    }

    private void Failure()
    {
        _onFailure.Invoke();
        failureAction?.Invoke();
        CancelActions();
    }

    private void OverSlurp()
    {
        _onFailure.Invoke();
        overSlurpAction?.Invoke();
        CancelActions();
    }

    private void CancelActions()
    {
        successAction = null;
        failureAction = null;
        overSlurpAction = null;
    }

    private void OnDestroy()
    {
        _button.action.performed -= Performed;
        _button.action.canceled -= Cancelled;
    }
}
