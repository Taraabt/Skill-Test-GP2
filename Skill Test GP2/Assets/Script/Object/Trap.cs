using UnityEngine;

public class Trap : MonoBehaviour
{

    [SerializeField]int damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

}
