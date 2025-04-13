//using UnityEditor.Experimental.GraphView;
//using UnityEngine;
//using UnityEngine.XR;

//public class Bullet : MonoBehaviour
//{
//    Rigidbody rb;
//    [SerializeField] float bulletSpeed;
//    public Vector3 direction;

//    private void OnEnable()
//    {
//        rb = GetComponent<Rigidbody>();
//        rb.linearVelocity =direction.normalized*bulletSpeed;    
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        this.gameObject.SetActive(false);
//    }
//}
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 10f;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direction.normalized * speed; // Imposta la velocità in base alla direzione
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }

}