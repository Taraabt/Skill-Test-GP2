using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    Input inputActions;

    protected virtual void Awake()
    {
        inputActions = new Input();
    }

    protected virtual void OnEnable()
    {
        inputActions.Enable();
        inputActions.Gameplay.XAxis.performed += RotX;
        inputActions.Gameplay.YAxis.performed += RotY;
        inputActions.Gameplay.Shoot.performed += Shoot;
        inputActions.Gameplay.Move.performed += Move;
        inputActions.Gameplay.Move.canceled += CancelMove;

    }

    protected virtual void OnDisable()
    {
        inputActions.Disable();
        inputActions.Gameplay.XAxis.performed -= RotX;
        inputActions.Gameplay.YAxis.performed -= RotY;
        inputActions.Gameplay.Shoot.performed -= Shoot;
        inputActions.Gameplay.Move.performed -= Move;
        inputActions.Gameplay.Move.canceled -= CancelMove;
    }

    protected virtual void Shoot(InputAction.CallbackContext value)
    {

    }

    protected virtual void Move(InputAction.CallbackContext value)
    {

    }

    protected virtual void CancelMove(InputAction.CallbackContext value)
    {

    }

    protected virtual void RotX(InputAction.CallbackContext context)
    {

    }

    protected virtual void RotY(InputAction.CallbackContext context)
    {

    }
}
