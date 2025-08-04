using UnityEngine;
using UnityEngine.InputSystem;

public class SobaGameLogic : MonoBehaviour
{
    [SerializeField] InputActionReference _button;

    bool _onTriggerStay = false;

    void Start()
    {
        _button.action.performed += Performed;
        _button.action.canceled += Cancelled;
    }

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerStay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _onTriggerStay = false;
    }


    private void CheckSuccess()
    {
        if (_onTriggerStay)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Failure");
        }
    }

    private void Performed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Pressed");
    }

    private void Cancelled(InputAction.CallbackContext ctx)
    {
        Debug.Log("Released");
        CheckSuccess();
    }

    private void OnDestroy()
    {
        _button.action.performed -= Performed;
        _button.action.canceled -= Cancelled;
    }
}
