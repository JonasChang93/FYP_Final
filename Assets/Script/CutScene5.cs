using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Playables;

public class CutScene5 : MonoBehaviour
{
    PlayerController playerController;
    Shooting shooting;

    public GameObject vCam5;
    public UIManagerGame ui;
    public Transform camZ;
    public PlayableDirector playableDirector;

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

    public void BossDead2()
    {
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();

        playerController.enabled = false;
        shooting.enabled = false;
        playerController.transform.position = transform.position + new Vector3(-5, 0, -5);

        camZ.localRotation = Quaternion.identity;
        camZ.parent.localRotation = Quaternion.identity;
        playerController.rotationX = 0;
    }

    public void CutSceneStart()
    {
        playerController.enabled = false;
        vCam5.SetActive(true);
        ui.PlayVideo();
    }
}
