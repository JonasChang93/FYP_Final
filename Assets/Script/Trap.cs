using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public TerrainCollider terrainCollider1;
    public TerrainCollider terrainCollider2;

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
        terrainCollider1.enabled = false;
        terrainCollider2.enabled = false;
        StartCoroutine(waitDead());
    }

    IEnumerator waitDead()
    {
        yield return new WaitForSeconds(1);
        PlayerData.instance.DeductHealth(PlayerData.instance.maxHealth);
    }
}
