using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    TMP_Text popUpText;
    Animator animator;

    public static PopUp instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        popUpText = GetComponent<TMP_Text>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPopUp(string text)
    {
        animator.Play("PopUp");
        popUpText.text = text;
    }
}
