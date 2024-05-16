using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFire : MonoBehaviour
{
    Transform ghostFireLocator;

    // Start is called before the first frame update
    void Start()
    {
        ghostFireLocator = GameObject.Find("GhostFireLocator").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenOtherOne()
    {
        Instantiate(gameObject, ghostFireLocator.position, Quaternion.identity);
    }

    public void GhostFireDead()
    {
        Destroy(gameObject);
    }
}
