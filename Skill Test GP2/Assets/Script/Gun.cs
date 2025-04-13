using UnityEngine;

public class Gun : MonoBehaviour
{
    bool IsShooting;

    public void Shoot(Transform muzle)
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = muzle.position;
            bullet.GetComponent<Bullet>().direction = muzle.transform.forward;
            bullet.SetActive(true);
            Debug.Log(muzle.transform.forward);
        }
    }

}
