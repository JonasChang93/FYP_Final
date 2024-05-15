using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Vector3 defaultDir;
    public float attackRadius = 15f;
    public float alertRadius = 20f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;

    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultDir = transform.parent.forward;
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

            //if Angle bigger then 90 with defaultAngle, then return
            float defaultAngle = Vector3.Angle(defaultDir, playerDir);
            float turningSpeed = defaultAngle < 90 ? 2 : 0;
            Vector3 tagetDir = Vector3.Slerp(forwardDir, playerDir, turningSpeed / angle);
            transform.LookAt(transform.position + tagetDir);

            if (distance < attackRadius && defaultAngle < 90 && !isAttacking)
            {
                // Attack
                isAttacking = true;
                StartCoroutine(Attacking());
            }
        }
    }
    IEnumerator Attacking()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.transform.forward * 20;
        Destroy(bullet, 2f);
        yield return new WaitForSeconds(1);
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
