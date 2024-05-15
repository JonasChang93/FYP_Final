using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;
    private void Awake()
    {
        //Update instantly
        instance = this;
    }
    #endregion

    public Queue<string> names;
    public Queue<string> sentences;

    public GameObject dialoguePanel;
    public TMP_Text nameText, sentenceText;

    //public GameObject choosePeanel;
    //public Text choose1, choose2;

    //public GameObject banner;
    //public Text coinUI;

    // Start is called before the first frame update
    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        names.Clear();
        sentences.Clear();

        for (int i = 0; i < dialogue.names.Length; i++)
        {
            names.Enqueue(dialogue.names[i]);
            sentences.Enqueue(dialogue.sentences[i]);
        }

        dialoguePanel.SetActive(true);

        DisplayNext();
    }

    public bool DisplayNext()
    {
        if (names.Count == 0)
        {
            dialoguePanel.SetActive(false);
            return false;
        }
        else
        {
            nameText.text = names.Dequeue();
            sentenceText.text = sentences.Dequeue();
            return true;
        }
    }

/*    public void ShowChoose()
    {
        choosePeanel.SetActive(true);
        choose1.text = "Upgrade (-5 coins)";
        choose2.text = "Leave";
    }*/

/*    public void Buy()
    {
        if(PlayerData.instance.coins >= 5f)
        {
            PlayerData.instance.coins -= 5f;
            banner.GetComponent<Banner>().PlayBanner("You bought a new weapon!");
            coinUI.text = "Money: $" + Convert.ToString(PlayerData.instance.coins);
            WeaponManager.instance.WeaponInstantiate(WeaponManager.instance.WeaponIDToGameObject(1));
        }
        else
        {
            banner.GetComponent<Banner>().PlayBanner("You have not enough money!");
            //weaponHolder.transform.GetChild(0).gameObject.SetActive(false);
            //Instantiate(weapon1, weaponHolder);
        }

        choosePeanel.SetActive(false);
        NPC.firsInteraction = true;
    }*/

/*    public void Leave()
    {
        choosePeanel.SetActive(false);
        NPC.firsInteraction = true;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
