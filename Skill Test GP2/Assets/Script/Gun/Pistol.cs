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
            bullet.GetComponent<Bullet>().Direction = muzle.transform.forward;
            bullet.GetComponent<Bullet>().BulletSpeed = projectileSpeed;
            bullet.GetComponent<Bullet>().Damage = damage;
            bullet.SetActive(true);
        }
    }

}
