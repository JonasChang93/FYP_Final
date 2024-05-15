using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Dialogue dialogue;
    static public bool firsInteraction = true;

    public override void Interact()
    {
        base.Interact();

        if (firsInteraction)
        {
            DialogueManager.instance.StartDialogue(dialogue);
            firsInteraction = false;
        }
        else
        {
            if (!DialogueManager.instance.DisplayNext())
            {
                //if (gameObject.name == "Seller")
                //{
                    //DialogueManager.instance.ShowChoose();
                //}
                //else
                //{
                    firsInteraction = true;
                //}
            }
        }
    }
}
