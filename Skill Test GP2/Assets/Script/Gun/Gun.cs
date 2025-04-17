using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public  bool WantShoot;
    protected bool IsShooting=false;
    [SerializeField]protected float shootTimer = 1;
    [SerializeField]protected float projectileSpeed;
    [SerializeField]protected Transform muzle;

    public virtual void Shoot()
    {

    }

}
