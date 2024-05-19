using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy4DeadAnimator : MonoBehaviour
{
    GameObject[] allParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        allParticle = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject p in allParticle)
        {
            Destroy(p);
        }
    }
}
