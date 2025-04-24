using UnityEngine;

public class Chest : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Bullet>()!=null)
        {
            Destroy(gameObject);
        }
    }

}
