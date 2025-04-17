using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayerInput
{

    [SerializeField]float speed;
    [SerializeField]float sensitivity = 1;
    [SerializeField]List<GameObject> gun = new List<GameObject>();
    [SerializeField] int hp;

    int gunIndex;
    Rigidbody rb;
    Vector2 move;
    float rotationX = 0f;
    float rotationY = 0f;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void Move(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();       
    }

    protected override void CancelMove(InputAction.CallbackContext value)
    {
        //UIManager.Health?.Invoke(hp);
        move = Vector2.zero;
    }
    protected override void SecondWeapon(InputAction.CallbackContext context)
    {

        gunIndex = 1;
        for (int i = 0; i < gun.Count; i++)
        {
            if (i == gunIndex)
            {
                gun[i].SetActive(true);
            }
            else
            {
                gun[i].SetActive(false);
            }
        }
    }

    protected override void FirstWeapon(InputAction.CallbackContext context)
    {
        gunIndex = 0;
        for (int i = 0; i < gun.Count; i++)
        {
            if (i == gunIndex)
            {
                gun[i].SetActive(true);
            }
            else
            {
                gun[i].SetActive(false);
            }
        }
    }

    protected override void ThirdWeapon(InputAction.CallbackContext context)
    {
        gunIndex = 2;
        for (int i = 0; i < gun.Count; i++)
        {
            if (i == gunIndex)
            {
                gun[i].SetActive(true);
            }
            else
            {
                gun[i].SetActive(false);
            }
        }
    }
    protected override void Shoot(InputAction.CallbackContext value)
    {
        gun[gunIndex].GetComponent<Gun>().Shoot();
    }
    protected override void StopShoot(InputAction.CallbackContext value)
    {
        gun[gunIndex].GetComponent<Gun>().WantShoot = false;
    }

    protected override void RotX(InputAction.CallbackContext value)
    {
        float x = value.ReadValue<float>();
        rotationY += x * sensitivity;
        rb.MoveRotation(Quaternion.Euler(rotationX, rotationY, 0));
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.TransformDirection(move.x, 0, move.y).normalized * speed;
    }

    protected override void RotY(InputAction.CallbackContext context)
    {

        float y = context.ReadValue<float>();
        rotationX -= y * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -75, 75);
        rb.MoveRotation(Quaternion.Euler(rotationX, rotationY, 0));
    }
}