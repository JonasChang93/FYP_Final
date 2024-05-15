using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aoyi : MonoBehaviour
{
    public Animator anim;
    public Avatar avatar;
    public Tower2 tower2;
    public EnemyAIMovement enemyAIMovement;
    public NavMeshAgent agent;

    public float damage = 50;
    float timer;
    BoxCollider[] colliders;
    public GameObject AttackShader;
    public GameObject SmokeEffect;
    bool isAttacking = false;
    bool isSpelling = false;

    // Start is called before the first frame update
    void Start()
    {
        colliders = gameObject.GetComponents<BoxCollider>();
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            AoyiAnimteStart();
            AttackShader.SetActive(true);
            if (timer > 12)
            {
                AttackShader.SetActive(false);
                AoyiAttack();
                if (timer > 14)
                {
                    AoyiEnd();
                }
            }
        }
    }

    void AoyiAnimteStart()
    {
        if (isSpelling) return;
        isSpelling = true;
        tower2.AoyiStart();
        tower2.enabled = false;
    }

    void AoyiAnimteEnd()
    {
        isSpelling = false;
        anim.Play("Idle");
        tower2.enabled = true;
    }


    void AoyiAttack()
    {
        if (isAttacking) return;
        isAttacking = true;
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = true;
        }
        StartCoroutine(SmokeEffectStart());
    }

    IEnumerator SmokeEffectStart()
    {
        SmokeEffect.SetActive(true);
        yield return new WaitForSeconds(2);
        SmokeEffect.SetActive(false);
        isAttacking = false;
    }

    void AoyiEnd()
    {
        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = false;
        }
        timer = 0;
        AoyiAnimteEnd();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerData.instance.DeductHealth(damage);
            AoyiEnd();
        }
    }
}
