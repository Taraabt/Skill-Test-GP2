using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayerInput,IDamageable
{

    [SerializeField]float speed;
    [SerializeField]float sensitivity = 1;
    [SerializeField]List<GameObject> gun = new List<GameObject>();
    [SerializeField]int stamina;
    public static Transform PlayerPos { get=>playerPos;}
    private static Transform playerPos;

    public static int Hp { get => hp; }
    [SerializeField] static int hp;

    int currentStamina;
    int gunIndex;
    Rigidbody rb;
    Vector2 move;
    float rotationX = 0f;
    float rotationY = 0f;
    bool IsMoving;

    protected override void Awake()
    {
        base.Awake();
        currentStamina=stamina;
        playerPos = transform;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void Move(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
        IsMoving = true;    
    }

    protected override void Swap(InputAction.CallbackContext value)
    {
        
        int temp= (int)value.ReadValue<Vector2>().y;
        if (temp ==-1)
        {
            gunIndex--;
            if(gunIndex < 0)
            {
                gunIndex =gun.Count-1;
            }
        }else if(temp == 1)
        {
            gunIndex++;
            if(gunIndex > gun.Count-1) {
                gunIndex=0;
            }
        }
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

    protected override void CancelMove(InputAction.CallbackContext value)
    {
        move = Vector2.zero;
        rb.linearVelocity = move;
        IsMoving = false;
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
        playerPos = transform;
        if (!IsMoving){
            if (currentStamina > stamina)
            {
                currentStamina = stamina;
                UIManager.Stamina?.Invoke(currentStamina);
            }
            else
            {
                currentStamina ++;
                UIManager.Stamina?.Invoke(currentStamina);
            }
        }
        else if(currentStamina>0)
        {
            rb.linearVelocity = transform.TransformDirection(move.x, 0, move.y).normalized*speed;
            currentStamina--;
            UIManager.Stamina?.Invoke(currentStamina);
        }else
        {
            rb.linearVelocity = transform.TransformDirection(move.x, 0, move.y).normalized;
        }      
    }

    protected override void RotY(InputAction.CallbackContext context)
    {

        float y = context.ReadValue<float>();
        rotationX -= y * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -75, 75);
        rb.MoveRotation(Quaternion.Euler(rotationX, rotationY, 0));
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void IsDead()
    {
        throw new System.NotImplementedException();
    }

    public void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }
}