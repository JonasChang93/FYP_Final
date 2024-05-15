using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    PlayerController playerController;
    public GameObject enemyType4Enter;
    public GameObject enemyType4;
    public GameObject cutScene8;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerData.instance.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOffCutScene8()
    {
        playerController.enabled = true;
        enemyType4Enter.SetActive(false);
        enemyType4.SetActive(true);
        cutScene8.SetActive(false);
    }
}
