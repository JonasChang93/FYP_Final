using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox1 : MonoBehaviour
{
    public Animator boxAnimator;
    public GameObject billboard;
    public GameObject healthModel;
    public float health;
    bool inActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PlayerData.instance.transform.position, transform.position);
        if (distance < 2 && Input.GetKeyDown(KeyCode.E) && !inActive)
        {
            inActive = true;
            billboard.SetActive(false);
            healthModel.SetActive(true);
            boxAnimator.Play("BoxOpen");
            StartCoroutine(GetHealth());
        }
    }

    IEnumerator GetHealth()
    {
        yield return new WaitForSeconds(3);
        PlayerData.instance.DeductHealth(-health);
        gameObject.SetActive(false);
    }
}
