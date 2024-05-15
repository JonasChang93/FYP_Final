using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class PlayerData : MonoBehaviour
{
    public GameObject postProcessing2;
    public Animator animator;
    public Slider healthBar;
    public Slider expBar;
    public TMP_Text levelUI;

    public bool isPlayer;
    public bool isDead = false;

    [HideInInspector] public float attack;
    [HideInInspector] public float defense;
    [HideInInspector] public float curHealth = 100;
    [HideInInspector] public float maxHealth = 100;
    [HideInInspector] public float exp;
    [HideInInspector] public float maxExp = 10;
    [HideInInspector] public float levels;
    
    bool levelUP;

    public static PlayerData instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeductHealth(float health)
    {
        curHealth -= health;
        curHealth = Mathf.Max(curHealth, 0f);
        curHealth = Mathf.Min(maxHealth, curHealth);

        if (curHealth <= 0)
        {
            if (isPlayer)
            {
                Banner.instance.PlayBanner("YOU DIE");
                animator.Play("Dead");
                postProcessing2.SetActive(true);
            }
            else
            {
                //isAttacking = false;
                Destroy(gameObject);
            }
            isDead = true;
        }
        UpdateUI();
    }

    public void LevelCheck()
    {
        if (exp >= maxExp)
        {
            levels += 1;
            levelUP = true;
            exp = 0;
            maxExp *= 2;

            if (levelUP)
            {
                attack += 5;
                defense += 5;

                PopUp.instance.PlayPopUp("You level up");
                levelUP = false;
            }
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        levelUI.text = "Level " + Convert.ToString(levels);
        healthBar.value = curHealth / maxHealth;
        expBar.value = exp / maxExp;
    }
}
