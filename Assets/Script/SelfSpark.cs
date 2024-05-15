using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpark : MonoBehaviour
{
    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isActive) StartCoroutine(SelfKill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SelfKill()
    {
        isActive = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        isActive = false;
    }
}
