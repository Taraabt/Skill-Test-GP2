using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Rifle : Gun
{
    public override void Shoot()
    {
        WantShoot = true;
        if (!IsShooting)
        {
            StartCoroutine(Shot(muzle));
        }
    }

    private void OnEnable()
    {
        IsShooting = false;
    }

    IEnumerator Shot(Transform muzle)
    {
        IsShooting = true;
        while (WantShoot)
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
            yield return new WaitForSeconds(shootTimer);
        }
        IsShooting = false;
    }
}
