using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform selfBulletLocator;
    public GameObject bullet;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ModeChange();
    }

    void ModeChange()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f)
        {
            Instantiate(bullet, selfBulletLocator.position, Quaternion.identity);
            timer = 0;
        }
    }
}
