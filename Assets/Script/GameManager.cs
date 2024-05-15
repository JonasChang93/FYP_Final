using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SceneEvent()
    {
        Application.targetFrameRate = 60;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                SaveLoadSettingManager.instance.LoadSetting();
                break;
            case 1:
                SaveLoadSettingManager.instance.LoadSetting();
                if (SaveLoadSettingManager.instance.loadGame)
                {
                    SaveLoadSettingManager.instance.loadGame = false;
                    //Turn off event if is load game(only beta)
                    SaveLoadGameManager.instance.LoadGame();
                    PlayerData.instance.UpdateUI();
                }
                break;
            default:
                SaveLoadSettingManager.instance.LoadSetting();
                break;
        }
    }
}
