using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail02 : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
    }

    void StartTimer()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5)
        {
            timer = 0;
            GameObject.Destroy(gameObject);
        }
    }
}
