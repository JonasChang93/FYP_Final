using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform targetLocator;
    public float range = 1;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = PlayerData.instance.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerData.instance.transform.position) < range)
        {
            controller.enabled = false;
            PlayerData.instance.transform.position = targetLocator.position;
            controller.enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
