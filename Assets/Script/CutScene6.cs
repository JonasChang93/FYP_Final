using System.Collections;
using UnityEngine;

public class CutScene6 : MonoBehaviour
{
    public GameObject miniMap, miniMapLocator;
    public Transform cameraY;
    public GameObject vCam6;
    public PlayerController playerController;
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        miniMapLocator.SetActive(true);
        miniMap.SetActive(true);
        StartCoroutine(CutSceneStart());
        characterController.radius = 0.1f;
    }

    private void OnTriggerExit(Collider other)
    {
        miniMapLocator.SetActive(false);
        miniMap.SetActive(false);
        StartCoroutine(CutSceneEnd());
        characterController.radius = 0.25f;
    }

    IEnumerator CutSceneStart()
    {
        vCam6.SetActive(true);
        //Wait 1s to start new control
        yield return new WaitForSeconds(1);
        playerController.modeChange = true;
        cameraY.rotation = Quaternion.identity;
    }

    IEnumerator CutSceneEnd()
    {
        vCam6.SetActive(false);
        //Wait 1s to start new control
        yield return new WaitForSeconds(1);
        playerController.modeChange = false;
    }
}
