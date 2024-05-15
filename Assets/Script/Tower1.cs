using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Tower1 : MonoBehaviour
{
    public Transform root, rootLocator;

    public float bulletSpeed = 10;
    public float turningSpeed = 2f;
    float attackRadius = 8f;
    float alertRadius = 12f;

    public GameObject SparkPrefab;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;
    public GameObject gunPrefab;
    public Transform gunSpawnPosition;
    public Avatar avatar;

    bool isAttacking = false;
    bool isShooting = false;

    Animator anim;
    EnemyAIMovement enemyAIMovement;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAIMovement = gameObject.GetComponent<EnemyAIMovement>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = PlayerData.instance.transform.position;
        float distance = Vector3.Distance(playerPosition, transform.position);

        if (distance < alertRadius)
        {
            if (distance > attackRadius && EnemyAIMovement.spotted)
            {
                agent.speed = 0;
                if (!isShooting) Instantiate(gunPrefab, gunSpawnPosition);
                isShooting = true;
                //Then start animation
                anim.avatar = null;
                anim.Play("Attack2");
                //Vector3 LookAt without y
                Transform target = transform;
                target.LookAt(playerPosition);
                Vector3 slerp = Vector3.Slerp(transform.forward, target.forward, Time.deltaTime);
                slerp.y = 0f;
                transform.forward = slerp;
                enemyAIMovement.enabled = false;

                if (!isAttacking)
                {
                    // Attack
                    isAttacking = true;
                    StartCoroutine(Attacking());
                }
            }
            else
            {
                RecoverMovement();
            }
        }
        else
        {
            RecoverMovement();
        }
    }

    void RecoverMovement()
    {
        agent.speed = 3;
        if (gunSpawnPosition.childCount > 0) DestroyWeapons(gunSpawnPosition.gameObject);
        anim.avatar = avatar;
        if (isShooting) anim.Play("Idle");
        isShooting = false;
        enemyAIMovement.enabled = true;
    }

    void DestroyWeapons(GameObject parent)
    {
        Transform[] weapons = parent.GetComponentsInChildren<Transform>();
        foreach (Transform weapon in weapons)
        {
            if (weapon.gameObject != parent) Destroy(weapon.gameObject);
        }
    }

    IEnumerator Attacking()
    {
        //Import locator rotation to root
        root.rotation = rootLocator.rotation;
        //Instantiate spark to gun
        Instantiate(SparkPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        //Instantiate bullet
        var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.transform.forward * bulletSpeed;
        yield return new WaitForSeconds(1);
        isAttacking = false;
        yield return new WaitForSeconds(3);
        if (gameObject) Destroy(bullet);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, alertRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
