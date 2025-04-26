using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    protected Input inputActions;

    protected virtual void Awake()
    {
        inputActions = new Input();
    }

    protected void OnEnable()
    {
        inputActions.Gameplay.Pause.started += Pause;
        inputActions.Gameplay.Interact.started += Interact;
        inputActions.Gameplay.Interact.canceled += StopInteract;
        inputActions.Gameplay.XAxis.performed += RotX;
        inputActions.Gameplay.YAxis.performed += RotY;
        inputActions.Gameplay.Shoot.performed += Shoot;
        inputActions.Gameplay.Shoot.canceled += StopShoot;
        inputActions.Gameplay.Move.performed += Move;
        inputActions.Gameplay.Move.canceled += CancelMove;
        inputActions.Gameplay.FirstWeapon.performed += FirstWeapon;
        inputActions.Gameplay.SecondWeapon.performed += SecondWeapon;
        inputActions.Gameplay.ThirdWeapon.performed += ThirdWeapon;
        inputActions.Gameplay.SwapWeapon.performed += Swap;
    }

    protected void OnDisable()
    {
        inputActions.Gameplay.Pause.started -= Pause;
        inputActions.Gameplay.Interact.started -= Interact;
        inputActions.Gameplay.Interact.canceled -= StopInteract;
        inputActions.Gameplay.XAxis.performed -= RotX;
        inputActions.Gameplay.YAxis.performed -= RotY;
        inputActions.Gameplay.Shoot.performed -= Shoot;
        inputActions.Gameplay.Shoot.canceled -= StopShoot;
        inputActions.Gameplay.Move.performed -= Move;
        inputActions.Gameplay.Move.canceled -= CancelMove;
        inputActions.Gameplay.FirstWeapon.performed -= FirstWeapon;
        inputActions.Gameplay.SecondWeapon.performed -= SecondWeapon;
        inputActions.Gameplay.ThirdWeapon.performed -= ThirdWeapon;
        inputActions.Gameplay.SwapWeapon.performed -= Swap;
    }

    protected virtual void Pause(InputAction.CallbackContext context)
    {

    }

    protected virtual void StopInteract(InputAction.CallbackContext context)
    {

    }

    protected virtual void Interact(InputAction.CallbackContext context)
    {

    }
    protected virtual void Swap(InputAction.CallbackContext context)
    {

    }

    protected virtual void SecondWeapon(InputAction.CallbackContext context)
    {

    }
    protected virtual void FirstWeapon(InputAction.CallbackContext context)
    {

    }

    protected virtual void ThirdWeapon(InputAction.CallbackContext context)
    {

    }

    protected virtual void Shoot(InputAction.CallbackContext value)
    {

    }

    protected virtual void StopShoot(InputAction.CallbackContext context)
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
