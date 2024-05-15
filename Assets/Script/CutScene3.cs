using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene3 : MonoBehaviour
{
    public GameObject vCam3;
    PlayerController playerController;
    Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerData.instance.gameObject.GetComponent<PlayerController>();
        shooting = PlayerData.instance.gameObject.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CutSceneStart()
    {
        playerController.modeChange = true;
        shooting.enabled = true;
        vCam3.SetActive(true);
    }

    public void CutSceneEnd()
    {
        playerController.modeChange = false;
        shooting.enabled = false;
        vCam3.SetActive(false);
    }
}
