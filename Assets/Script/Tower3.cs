using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Tower3 : MonoBehaviour
{
    public float bulletSpeed = 10;
    public float turningSpeed = 2f;
    float attackRadius = 8f;
    float alertRadius = 12f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;

    bool isAttacking = false;
    bool isShooting = false;

    Animator anim;
    //public Avatar avatar;
    EnemyAIMovement1 enemyAIMovement;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAIMovement = gameObject.GetComponent<EnemyAIMovement1>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = PlayerData.instance.transform.position;
        float distance = Vector3.Distance(playerPosition, transform.position);

        if (distance < alertRadius)
        {
            //Look at player
            Vector3 forwardDir = Vector3.Normalize(transform.forward);
            Vector3 playerDir = Vector3.Normalize(playerPosition - transform.position);
            float angle = Vector3.Angle(forwardDir, playerDir);
            Vector3 tagetDir = Vector3.Slerp(forwardDir, playerDir, turningSpeed / angle);

            agent.speed = 0;
            //if (!isShooting) Instantiate(gunPrefab, gunSpawnPosition);
            isShooting = true;
            //anim.avatar = null;
            transform.LookAt(transform.position + tagetDir);
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

    void RecoverMovement()
    {
        agent.speed = 3;
        //if (gunSpawnPosition.childCount > 0) DestroyWeapons(gunSpawnPosition.gameObject);
        //anim.avatar = avatar;
        if (isShooting) anim.Play("Idle");
        isShooting = false;
        enemyAIMovement.enabled = true;
    }

/*    void DestroyWeapons(GameObject parent)
    {
        Transform[] weapons = parent.GetComponentsInChildren<Transform>();
        foreach (Transform weapon in weapons)
        {
            if (weapon.gameObject != parent) Destroy(weapon.gameObject);
        }
    }*/

    IEnumerator Attacking()
    {
        anim.Play("Attack2");
        yield return new WaitForSeconds(1);
        //Loop bullet
        float angle = 0;
        while (angle <= 360)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.Euler(0, angle, 0));
            Destroy(bullet, 4);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.transform.forward * bulletSpeed;
            angle += 45;
        }
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, alertRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
