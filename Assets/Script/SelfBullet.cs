using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBullet : MonoBehaviour
{
    GameObject modelBox;
    Rigidbody rb;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        modelBox = GameObject.Find("ModelBox");
        if (modelBox) rb.AddForce(modelBox.transform.forward * 512);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyType1Data enemyData = other.GetComponent<EnemyType1Data>();
        if (enemyData) enemyData.DeductHealth(5);
    }
}
