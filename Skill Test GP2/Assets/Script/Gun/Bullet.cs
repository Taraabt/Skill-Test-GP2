using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed;
    public Vector3 direction;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direction.normalized * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }

}
