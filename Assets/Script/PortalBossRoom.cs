using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBossRoom : MonoBehaviour
{
    Transform bossRoomLocator;
    public float range = 1;

    // Start is called before the first frame update
    void Start()
    {
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
            if (bossRoomLocator) PlayerData.instance.transform.position = bossRoomLocator.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
