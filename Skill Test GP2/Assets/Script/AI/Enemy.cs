using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{

    int i = 0;    
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] transforms;
    [SerializeField] int points;
    [SerializeField] float fieldOfViewAngle = 60f;
    Gun gun;
    public int Hp { get => hp; }
    [SerializeField] int hp;
    bool playerFound;
    bool isDead = false;
    void Awake()
    {
        playerFound = false;
        gun=this.GetComponentInChildren<Gun>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        navMeshAgent.destination = transforms[i].position;
    }

    private void FixedUpdate()
    {
        if (playerFound) {
            transform.forward = Player.PlayerPos.position-transform.position;
        }
        if (Vector3.Distance(transform.position, transforms[i].position)<1.1f)
        {
            i++;
            if (i==transforms.Length)
            {
                i = 0;
            }
            navMeshAgent.destination = transforms[i].position;
        }
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet=collision.gameObject.GetComponent<Bullet>();
        if (bullet!=null)
        {
            TakeDamage(bullet.Damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 directionToPlayer = (other.transform.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleToPlayer <= fieldOfViewAngle)
        {
            navMeshAgent.destination = this.transform.position;
            playerFound = true;
            transform.forward = Player.PlayerPos.position;
            gun.Shoot();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 directionToPlayer = (other.transform.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        if (angleToPlayer <= fieldOfViewAngle)
        {
            navMeshAgent.destination = this.transform.position;
        }
    }

    public void TakeDamage(int amount)
    {
        hp = hp-amount;
        if (hp <= 0&&!isDead)
        {
            IsDead();
            isDead = true;
        }
    }

    public void IsDead()
    {
        Destroy(gameObject);
        UIManager.Score?.Invoke(points);
    }

    public void Heal(int amount)
    {

    }

}
