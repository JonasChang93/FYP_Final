using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSettingManager : MonoBehaviour
{
    AudioSource audioSource;

    public Toggle audioToggle;
    public Slider audioSlider;
    public Slider mouseSlider;
    public Dropdown resolutionDropdown;
    public Toggle offsetX_toggle;
    public Toggle offsetY_toggle;

    int dropdownIndex = 0;
    float mouseSliderFloat = 1;

    [HideInInspector] public float offsetX = 1;
    [HideInInspector] public float offsetY = 1;
    [HideInInspector] public float rotatingSpeed = 10;
    [HideInInspector] public bool loadGame = false;

    public static SaveLoadSettingManager instance;
    private void Awake()
    {
        instance = this;
        GetAllComponent();
    }

    void GetAllComponent()
    {
        audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSetting()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create("./SettingData.dat");
        SettingData saveData = new SettingData();

        //Save from component
        saveData.bgmVolume = audioSource.volume;
        saveData.bgmMute = audioSource.mute;

        //Save from script
        saveData.offsetX = offsetX;
        saveData.offsetY = offsetY;
        saveData.dropdownIndex = dropdownIndex;
        saveData.mouseSliderFloat = mouseSliderFloat;
        saveData.loadGame = loadGame;

        binaryFormatter.Serialize(file, saveData);
        file.Close();

        ReloadSetting();
        Debug.Log("Setting saved!");
    }

    public void LoadSetting()
    {
        if (File.Exists("./SettingData.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open("./SettingData.dat", FileMode.Open);
            SettingData saveData = (SettingData)binaryFormatter.Deserialize(file);

            //Load to script
            audioSlider.value = saveData.bgmVolume;
            audioToggle.isOn = saveData.bgmMute;
            offsetX = saveData.offsetX;
            offsetY = saveData.offsetY;
            dropdownIndex = saveData.dropdownIndex;
            mouseSliderFloat = saveData.mouseSliderFloat;
            loadGame = saveData.loadGame;

            file.Close();

            ReloadSetting();
            Debug.Log("Setting loaded!");
        }
        else
        {
            SaveSetting();

            Debug.Log("No setting! New setting Created");
        }
    }

    public void ReloadSetting()
    {
        resolutionDropdown.value = dropdownIndex;
        ResolutionDropdown(resolutionDropdown.value);

        mouseSlider.value = mouseSliderFloat;
        MouseSlider(mouseSlider.value);

        offsetX_toggle.isOn = offsetX > 0 ? false : true;
        offsetY_toggle.isOn = offsetY > 0 ? false : true;
        OffsetX_toggle(offsetX_toggle.isOn);
        OffsetY_toggle(offsetY_toggle.isOn);
    }

    public void OffsetY_toggle(bool isOn)
    {
        offsetY = isOn ? -1 : 1;
    }

    public void OffsetX_toggle(bool isOn)
    {
        offsetX = isOn ? -1 : 1;
    }

    public void MouseSlider(float value)
    {
        mouseSliderFloat = value;
        rotatingSpeed = 10 * mouseSliderFloat;
    }

    public void DropdownIndex(int option)
    {
        dropdownIndex = option;
        
        ResolutionDropdown(option);
    }

    public void ResolutionDropdown(int option)
    {
        int screenWidth;
        int screenHeight;
        
        switch (option)
        {
            case 0:
                screenWidth = 1920;
                screenHeight = 1080;
                break;
            case 1:
                screenWidth = 2560;
                screenHeight = 1440;
                break;
            case 2:
                screenWidth = 1280;
                screenHeight = 720;
                break;
            default:
                screenWidth = 1920;
                screenHeight = 1080;
                break;
        }
        
        Screen.SetResolution(screenWidth, screenHeight, false);
    }
}

[Serializable]
class SettingData
{
    public float bgmVolume;
    public bool bgmMute;
    public int dropdownIndex;
    public float offsetX;
    public float offsetY;
    public float mouseSliderFloat;
    public bool loadGame;
}
