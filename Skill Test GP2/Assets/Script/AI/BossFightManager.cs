using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] GameObject door;

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.GetComponent<Player>() != null)
        {
            Boss.Activation?.Invoke();
            door.SetActive(true);
        }
    }


}
