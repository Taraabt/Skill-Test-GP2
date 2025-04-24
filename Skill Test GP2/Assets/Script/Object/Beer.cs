using UnityEngine;

public class Beer : MonoBehaviour
{

    [SerializeField] int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>()!=null)
        {
            Player.heal?.Invoke(amount);
            Destroy(gameObject);
        }
    }

}
