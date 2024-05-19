using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAnimator : MonoBehaviour
{
    public GameObject Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenTutorial()
    {
        if (this.enabled) Tutorial.SetActive(true);
    }

    void CloseTutorial()
    {
        Tutorial.SetActive(false);
    }
}
