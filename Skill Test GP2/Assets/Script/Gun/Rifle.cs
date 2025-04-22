using System.Collections;
using UnityEngine;

public class Rifle : Gun
{
    public override void Shoot()
    {
        WantShoot = true;
        if (!isShooting)
        {
            StartCoroutine(Shot(muzle));
        }
    }

    private void OnEnable()
    {
        isShooting = false;
    }

    IEnumerator Shot(Transform muzle)
    {
        isShooting = true;
        while (WantShoot)
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
            yield return new WaitForSeconds(shootTimer);
        }
        isShooting = false;
    }
}
