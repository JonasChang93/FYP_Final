using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    public Animator ink;

    public static Banner instance;
    private void Awake()
    {
        instance = this;
    }

    public void PlayBanner(string text)
    {
        GetComponent<Text>().text = text;
        GetComponent<Animator>().Play("FadeIn");
        ink.gameObject.SetActive(true);
        ink.Play("Ink3to1");
    }
}
