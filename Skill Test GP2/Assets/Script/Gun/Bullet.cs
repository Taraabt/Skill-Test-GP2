using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody rb;
    public float BulletSpeed;
    public Vector3 Direction;
    public int Damage;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Direction.normalized * BulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }

}
