using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CutScene5 : MonoBehaviour
{
    bool inCutScene = false;
    public GameObject vCam5;
    PlayerController playerController;
    public UIManagerGame ui;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerData.instance.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossDead2()
    {
        if (!inCutScene) StartCoroutine(CutSceneEnd());
    }

    IEnumerator CutSceneEnd()
    {
        inCutScene = true;
        ui.BlackOut(true);
        //Wait black
        yield return new WaitForSeconds(1);
        ui.BlackIn(false);
        playerController.enabled = false;
        vCam5.SetActive(true);
        ui.PlayVideo();
        inCutScene = false;
        //CutScene1 gameObject die
    }
}
