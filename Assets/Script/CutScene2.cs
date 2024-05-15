using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene2 : MonoBehaviour
{
    bool inCutScene = false;
    public GameObject vCam2;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerData.instance.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!inCutScene) StartCoroutine(CutSceneEnd());
    }

    IEnumerator CutSceneEnd()
    {
        inCutScene = true;
        playerController.enabled = false;
        vCam2.SetActive(true);
        yield return new WaitForSeconds(4);
        vCam2.SetActive(false);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        playerController.enabled = true;
        inCutScene = false;
        //CutScene1 gameObject die
    }
}
