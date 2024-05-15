using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class EnemyAIMovement1 : MonoBehaviour
{
    public GameObject selfSparkPrefab;
    Transform selfSparkLocator;
    Vector3 newPlayerPosition;
    Vector3 destination;

    public Transform[] locators;

    float alertRadius = 16;
    float attackRadius = 2;

    bool isTracking = false;
    bool isAttacking = false;
    float attack = 4;

    Animator animator;
    NavMeshAgent agent;

    public static bool spotted = false;

    // Start is called before the first frame update
    void Start()
    {
        selfSparkLocator = GameObject.Find("SelfSparkLocator").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (locators.Length == 3)
        {
            destination = locators[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Distance
        Vector3 playerPosition = PlayerData.instance.transform.position;
        float distance = Vector3.Distance(playerPosition, transform.position);

        //Ray
        Vector3 origin = transform.position + new Vector3(0, 1.5f);
        Vector3 direction = Vector3.Normalize(playerPosition - transform.position);
        Ray ray = new Ray(origin, direction);

        //Vector3 direction
        Vector3 playerDir = Vector3.Normalize(playerPosition - transform.position);
        Vector3 enemyDir = transform.forward;
        float angle = Vector3.Angle(playerDir, enemyDir);

        RaycastHit hit;
        if (distance < alertRadius)
        {
            if (Physics.Raycast(ray, out hit))
            {
                spotted = hit.collider.tag == "Player" && angle < 90 ? true : false;
                if (spotted || (hit.collider.tag == "Player" && isTracking))
                {
                    isTracking = true;
                    newPlayerPosition = playerPosition;

                    if (distance < attackRadius)
                    {
                        Rotate(enemyDir, playerDir);
                        //Attack
                        animator.SetBool("isWalking", false);
                        if (!isAttacking)
                        {
                            isAttacking = true;
                            animator.Play("Attack");
                            StartCoroutine(Attacking());
                            agent.ResetPath();
                        }
                    }
                    else
                    {
                        Walk();
                    }
                }
                else if (isTracking)
                {
                    Walk();
                    if (Vector3.Distance(transform.position, newPlayerPosition) < 0.1f)
                    {
                        EndTeacking();
                    }
                }
                else
                {
                    if (distance < attackRadius)
                    {
                        Rotate(enemyDir, playerDir);

                        //Do nothing
                        animator.SetBool("isWalking", false);
                        agent.ResetPath();
                    }
                    else if (!isTracking)
                    {
                        Patrol();
                    }
                }
            }
        }
        else
        {
            float randomRangeX =  Random.Range(-1f, 1f) * 4;
            float randomRangeZ = Random.Range(-1f, 1f) * 4;
            Debug.Log(randomRangeX);
            randomRangeX = randomRangeX > 0 ? randomRangeX + 2 : randomRangeX - 2;
            randomRangeZ = randomRangeZ > 0 ? randomRangeZ + 2 : randomRangeZ - 2;
            transform.position = playerPosition + new Vector3(randomRangeX, 0, randomRangeZ);
            Debug.Log(randomRangeX);
            Patrol();
        }
    }

    void Patrol()
    {
        if (locators.Length != 3)
        {
            return;
        }

        //Patrol to destination
        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            if (destination == locators[0].position)
            {
                destination = locators[1].position;
            }
            else if (destination == locators[1].position)
            {
                destination = locators[2].position;
            }
            else if (destination == locators[2].position)
            {
                destination = locators[0].position;
            }
        }

        animator.SetBool("isWalking", true);
        agent.SetDestination(destination);
    }

    void Walk()
    {
        //Walk towards player
        animator.SetBool("isWalking", true);
        agent.SetDestination(newPlayerPosition);
    }

    void Rotate(Vector3 enemyDir, Vector3 playerDir)
    {
        //Rotate to player
        Vector3 targetDir = Vector3.Slerp(enemyDir, playerDir, Time.deltaTime * 2);
        targetDir.y = 0;
        transform.LookAt(transform.position + targetDir);
    }

    void EndTeacking()
    {
        isTracking = false;
        //Do nothing
        animator.SetBool("isWalking", false);
        agent.ResetPath();
    }

    public void StartTeacking()
    {
        isTracking = true;
    }

    IEnumerator Attacking()
    {
        //Wait then reduce health
        PlayerData.instance.DeductHealth(attack);
        Quaternion quaternion = Quaternion.LookRotation(transform.position - PlayerData.instance.transform.position);
        Instantiate(selfSparkPrefab, selfSparkLocator.transform.position, quaternion);
        yield return new WaitForSeconds(1);

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
