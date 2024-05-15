using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CutScene7 : MonoBehaviour
{
    public Transform cameraY;
    public GameObject vCam7;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(CutSceneStart());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(CutSceneEnd());
    }

    IEnumerator CutSceneStart()
    {
        vCam7.SetActive(true);
        //Wait 1s to start new control
        yield return new WaitForSeconds(1);
        Vector3 forward = vCam7.transform.forward;
        forward.y = 0f;
        cameraY.rotation = Quaternion.LookRotation(forward);
    }

    IEnumerator CutSceneEnd()
    {
        vCam7.SetActive(false);
        //Wait 1s to start new control
        yield return new WaitForSeconds(1);
        cameraY.rotation = Quaternion.identity;
    }
}
