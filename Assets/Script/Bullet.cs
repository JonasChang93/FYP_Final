using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
    public GameObject trail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            StartCoroutine(Hit());
        }
        if (other.gameObject.tag == "Player")
        {
            PlayerData.instance.DeductHealth(1);
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        particle.SetActive(true);
        trail.SetActive(false);
        //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
        if (gameObject) Destroy(gameObject);
    }
}
