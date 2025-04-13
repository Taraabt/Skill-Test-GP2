using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayerInput
{

    [SerializeField]float speed;
    [SerializeField]float sensitivity = 1;
    [SerializeField] Gun gun;
    [SerializeField] Transform muzle;

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
        move = Vector2.zero;
    }

    protected override void Shoot(InputAction.CallbackContext value)
    {
        gun.Shoot(muzle);
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