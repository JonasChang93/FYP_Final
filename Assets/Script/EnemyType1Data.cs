using System;
using System.Collections;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class EnemyType1Data : MonoBehaviour
{
    public Material[] deadMaterials;
    public SkinnedMeshRenderer smr;
    Animator animator;
    bool isDying = false;
    public Slider healthBar;
    public GameObject healthBarParent;
    public Transform portalLocator, boxLocator;
    public GameObject portalPrefab, boxPrefab;
    public GameObject particlePrefab;

    public bool isPlayer = false;

    [HideInInspector] public float attack;
    [HideInInspector] public float defense;
    [HideInInspector] public float curHealth = 100;
    [HideInInspector] public float maxHealth = 100;

    public CutScene4 cutScene4;
    public CutScene5 cutScene5;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (gameObject.name == "EnemyType5") healthBarParent.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeductHealth(float health)
    {
        curHealth -= health;
        curHealth = Mathf.Max(curHealth, 0f);
        healthBar.value = curHealth / maxHealth;

        if (curHealth <= 0)
        {
            if (isPlayer)
            {
                Banner.instance.PlayBanner("You die");
            }
            else
            {
                if (!isDying) StartCoroutine(EnemyDie());
            }
        }
    }

    IEnumerator EnemyDie()
    {
        isDying = true;
        //Kill enemy script
        var enemyAIMovement = GetComponentInChildren<EnemyAIMovement>();
        var tower = GetComponentInChildren<Tower>();
        var tower1 = GetComponentInChildren<Tower1>();
        var tower2 = GetComponentInChildren<Tower2>();
        var tower3 = GetComponentInChildren<Tower3>();
        if (enemyAIMovement != null) enemyAIMovement.enabled = false;
        if (tower != null) tower.enabled = false;
        if (tower1 != null) tower1.enabled = false;
        if (tower2 != null) tower2.enabled = false;
        if (tower3 != null) tower3.enabled = false;
        animator.Play("Dead");
        //Give exp
        if (gameObject.name.Substring(0, 10) == "EnemyType1")
        {
            PlayerData.instance.exp += 10;
            yield return new WaitForSeconds(2);
            if (smr != null) smr.materials = deadMaterials;
            Instantiate(particlePrefab, transform);
            yield return new WaitForSeconds(2);
        }
        if (gameObject.name.Substring(0, 10) == "EnemyType2")
        {
            PlayerData.instance.exp += 10;
            yield return new WaitForSeconds(2);
            if (smr != null) smr.materials = deadMaterials;
            Instantiate(particlePrefab, transform);
            yield return new WaitForSeconds(2);
        }
        if (gameObject.name.Substring(0, 10) == "EnemyType3")
        {
            PlayerData.instance.exp += 20;
            yield return new WaitForSeconds(2);
            if (smr != null) smr.materials = deadMaterials;
            Instantiate(particlePrefab, transform);
            yield return new WaitForSeconds(2);
            Instantiate(portalPrefab, portalLocator);
            Instantiate(boxPrefab, boxLocator);
        }
        if (gameObject.name.Substring(0, 10) == "EnemyType4")
        {
            PlayerData.instance.exp += 30;
            //Start cutScene
            cutScene4.BossDead1();
            //Wait enemy dead
            yield return new WaitForSeconds(1);
        }
        if (gameObject.name.Substring(0, 10) == "EnemyType5")
        {
            //Start cutScene
            cutScene5.BossDead2();
            //Wait enemy dead
            yield return new WaitForSeconds(1);
        }
        PlayerData.instance.LevelCheck();
        Destroy(gameObject);
        isDying = false;
    }
}
