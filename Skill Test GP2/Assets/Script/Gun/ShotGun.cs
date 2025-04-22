using System.Collections;
using UnityEngine;

public class ShotGun : Gun
{
    int nBullet=4;
    [SerializeField]Transform[] sgMuzle;

    public override void Shoot()
    {
        WantShoot = true;
        if (!isShooting)
        {
            StartCoroutine(Shot(sgMuzle));
        }
    }

    private void OnEnable()
    {
        isShooting = false;
    }

    IEnumerator Shot(Transform[] muzle)
    {
        isShooting = true;
        while (WantShoot)
        {
            GameObject[] bullet= new GameObject[nBullet];
            for (int i=0;i<nBullet;i++)
            {
                bullet[i]= ObjectPool.instance.GetPooledObject();
                if (bullet[i] != null)
                {
                    bullet[i].transform.position = muzle[i].position;
                    bullet[i].transform.rotation = muzle[i].rotation;
                    bullet[i].GetComponent<Bullet>().Direction = muzle[i].transform.forward;
                    bullet[i].GetComponent<Bullet>().BulletSpeed = projectileSpeed;
                    bullet[i].GetComponent<Bullet>().Damage = damage;
                    bullet[i].SetActive(true);
                }
            }
            yield return new WaitForSeconds(shootTimer);
        }
        isShooting = false;
    }
}