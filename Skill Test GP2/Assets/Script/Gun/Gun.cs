using UnityEngine;

public class Gun : MonoBehaviour
{

    public  bool WantShoot;
    protected bool isShooting=false;
    [SerializeField]protected float shootTimer = 1;
    [SerializeField]protected float projectileSpeed;
    [SerializeField]protected Transform muzle;
    [SerializeField]protected int damage;

    public virtual void Shoot()
    {

    }

}
