using System;
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{

    public static Action Activation;
    public int Hp =>hp;
    [SerializeField]int hp;
    [SerializeField] int damage;
    [SerializeField] float projectileSpeed1;
    [SerializeField] float projectileSpeed2;
    [SerializeField] Transform[] muzle;
    int nBullet = 8;
    int phaseTrigger;

    private void Awake()
    {
        phaseTrigger = 0;
    }
     
    private void OnEnable()
    {
        Activation += ActiveBossFight;
    }

    private void OnDisable()
    {
        Activation -= ActiveBossFight;
    }

    private void ActiveBossFight()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {        
        while (phaseTrigger==0)
        {
            GameObject bullet = BossPool.instance.GetPooledObject();
            if (bullet != null)
            {
                Vector3 pos = new Vector3(Player.PlayerPos.transform.position.x, Player.PlayerPos.transform.position.y+50, Player.PlayerPos.transform.position.z);
                bullet.transform.position = pos;
                bullet.GetComponent<Bullet>().Direction = Vector3.down;
                bullet.GetComponent<Bullet>().BulletSpeed = projectileSpeed1;
                bullet.GetComponent<Bullet>().Damage = damage;
                bullet.SetActive(true);
            }
            yield return new WaitForSeconds(1);
        }
        if (phaseTrigger==1)
        {
            StartCoroutine(Attack2());
        }
    }

    IEnumerator Attack2()
    {
        transform.forward = Player.PlayerPos.position - transform.position;
        while (phaseTrigger == 1)
        {
            GameObject[] bullet = new GameObject[nBullet];
            for (int i = 0; i < nBullet; i++)
            {
                bullet[i] = BossPool.instance.GetPooledObject();
                if (bullet[i] != null)
                {
                    bullet[i].transform.position = muzle[i].position;
                    bullet[i].transform.rotation = muzle[i].rotation;
                    bullet[i].GetComponent<Bullet>().Direction = muzle[i].transform.forward;
                    bullet[i].GetComponent<Bullet>().BulletSpeed = projectileSpeed2;
                    bullet[i].GetComponent<Bullet>().Damage = damage;
                    bullet[i].SetActive(true);
                }
            }
            yield return new WaitForSeconds(1);
        }
        if (phaseTrigger == 0)
        {
            StartCoroutine(Attack());
        }
    }

    public void Heal(int amount)
    {
        //nothing?!
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.Damage);
        }
    }

    public void IsDead()
    {
        Player.deactiveInput?.Invoke();
        Cursor.lockState = CursorLockMode.Confined;
        UIManager.Win?.Invoke();
        Time.timeScale = 0;
    }

    public void TakeDamage(int amount)
    {
        if (phaseTrigger == 0)
        {
            phaseTrigger = 1;
        }
        else
        {
            phaseTrigger = 0;
        }
        hp = hp - amount;
        if (hp<=0)
        {
            IsDead();
        }
    }
}
