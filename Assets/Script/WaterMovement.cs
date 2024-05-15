using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    float movement = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = transform.localPosition.z > 2 ? -1 : movement;
        movement = transform.localPosition.z < -2 ? 1 : movement;
        transform.Translate(0, 0, movement * Time.deltaTime);
    }
}
