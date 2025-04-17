using UnityEngine;

public class Pistol : Gun
{
    public override void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = muzle.position;
            bullet.transform.rotation = muzle.rotation;
            bullet.GetComponent<Bullet>().direction = muzle.transform.forward;
            bullet.GetComponent<Bullet>().bulletSpeed = projectileSpeed;
            bullet.SetActive(true);
        }
    }

}
