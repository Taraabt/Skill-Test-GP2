using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayerInput, IDamageable
{

    public static Action<int> heal;

    [SerializeField]float speed;
    [SerializeField]float sensitivity = 1;
    [SerializeField]List<GameObject> gun = new List<GameObject>();
    [SerializeField]int stamina;
    [SerializeField]int hp;
    public static Transform PlayerPos { get=>playerPos;}
    private static Transform playerPos;

    public int Hp { get=> hp; }
    public bool IsInteracting { get => isInteracting; }

    int currentStamina;
    int currentHp;
    int gunIndex;
    Rigidbody rb;
    Vector2 move;
    float rotationX = 0f;
    float rotationY = 0f;
    bool isMoving;
    bool isInteracting;

    void OnEnable()
    {
        base.OnEnable();
        heal += Heal;
    }

    void OnDisable()
    {
        base.OnDisable();
        heal -= Heal;
    }

    protected override void Awake()
    {
        base.Awake();
        inputActions.Gameplay.Enable();
        currentHp = hp;
        currentStamina =stamina;
        playerPos = transform;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void Move(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
        isMoving = true;    
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

    protected override void Interact(InputAction.CallbackContext context)
    {
        isInteracting = true;
    }

    protected override void StopInteract(InputAction.CallbackContext context)
    {
        isInteracting= false;
    }

    protected override void CancelMove(InputAction.CallbackContext value)
    {
        move = Vector2.zero;
        rb.linearVelocity = move;
        isMoving = false;
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
        if (!isMoving){
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()!=null)
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHp = currentHp - amount;
        UIManager.Health?.Invoke(currentHp);
        if (currentHp <= 0)
        {
            IsDead();
        }
    }

    public void IsDead()
    {
        inputActions.Gameplay.Disable();
    }

    public void Heal(int amount)
    {
        currentHp = currentHp + amount;
        if(currentHp>= hp) { 
            currentHp=hp;
        }
        UIManager.Health?.Invoke(currentHp);
    }

}