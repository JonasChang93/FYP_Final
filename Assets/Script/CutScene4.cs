using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CutScene4 : MonoBehaviour
{
    bool inCutScene = false;
    public GameObject vCam4;
    PlayerController playerController;
    public CutScene3 cutScene3;
    public Enemy4DeadAnimator enemy4DeadAnimator;
    public GameObject enemy5;
    public UIManagerGame ui;
    public Transform cameraY;
    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerData.instance.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossDead1()
    {
        if (!inCutScene) StartCoroutine(CutSceneEnd());
    }

    IEnumerator CutSceneEnd()
    {
        inCutScene = true;
        ui.BlackOut(true);
        //Wait black
        yield return new WaitForSeconds(1);
        playerController.enabled = false;
        playerController.transform.position = transform.position + new Vector3(2, 0, 2);
        cameraY.rotation = Quaternion.identity;
        vCam4.SetActive(true);
        //Wait camera transition
        yield return new WaitForSeconds(2);
        ui.BlackIn(false);
        enemy4DeadAnimator.gameObject.SetActive(true);
        enemy4DeadAnimator.PlayAnimation();
        //Wait Timeline transition, change bgm
        audioSource.clip = clip;
        yield return new WaitForSeconds(4);
        audioSource.Play();
        yield return new WaitForSeconds(2);
        vCam4.SetActive(false);
        cutScene3.CutSceneStart();
        //Wait camera transition
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        playerController.enabled = true;
        Destroy(enemy4DeadAnimator.gameObject);
        enemy5.SetActive(true);
        inCutScene = false;
        //CutScene1 gameObject die
    }
}
