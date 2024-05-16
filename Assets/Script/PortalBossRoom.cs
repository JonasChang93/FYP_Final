using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBossRoom : MonoBehaviour
{
    Transform bossRoomLocator;
    public float range = 1;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = PlayerData.instance.gameObject.GetComponent<CharacterController>();
        //Find locator in scenes
        if (GameObject.Find("BossRoomLocator"))
        {
            bossRoomLocator = GameObject.Find("BossRoomLocator").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerData.instance.transform.position) < range)
        {
            if (bossRoomLocator)
            {
                controller.enabled = false;
                PlayerData.instance.transform.position = bossRoomLocator.position;
                controller.enabled = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
