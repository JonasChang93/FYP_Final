using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIManagerStart : MonoBehaviour
{
    public GameObject ink;
    public GameObject bg;
    public GameObject black;
    public GameObject btnGroup;
    public GameObject settingDialogue;
    public GameObject openingImage;
    public AudioSource audioSource;
    VideoPlayer openingVideo;

    void Start()
    {
        openingVideo = GetComponent<VideoPlayer>();
        openingVideo.loopPointReached += OnVideoEnd;

        StartCoroutine(BlackIn());
    }

    void InkIn()
    {
        ink.GetComponent<Animator>().Play("Ink3to1");
    }

    void InkOut()
    {
        ink.GetComponent<Animator>().Play("Ink1to3");
    }

    void BGOut()
    {
        bg.GetComponent<Animator>().Play("FadeOut");
    }

    void BGIn()
    {
        bg.SetActive(true);
        bg.GetComponent<Animator>().Play("FadeIn");
    }

    IEnumerator BlackIn()
    {
        black.SetActive(true);
        black.GetComponent<Animator>().Play("FadeIn");
        yield return new WaitForSeconds(1);

        black.SetActive(false);
    }

/*    IEnumerator BlackOut()
    {
        black.SetActive(true);
        black.GetComponent<Animator>().Play("FadeOut");
        yield return new WaitForSeconds(1);
    }*/

    public void NewGame()
    {
        StartCoroutine(BlackIn());

        openingImage.SetActive(true);
        audioSource.clip = null;
        openingVideo.Play();
    }

    public void LoadGame()
    {
        SaveLoadSettingManager.instance.loadGame = true;
        SaveLoadSettingManager.instance.SaveSetting();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        black.SetActive(true);
        black.GetComponent<Animator>().Play("FadeOut");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game");
    }

    void OnVideoEnd(VideoPlayer videoPlayer)
    {
        StartCoroutine(LoadScene());
    }

    public void OpenDialog()
    {
        btnGroup.GetComponent<Animator>().Play("MoveOut");
        settingDialogue.GetComponent<Animator>().Play("MoveIn");
        BGIn();
        InkIn();
    }
    public void CloseDialog()
    {
        btnGroup.GetComponent<Animator>().Play("MoveIn");
        settingDialogue.GetComponent<Animator>().Play("MoveOut");
        BGOut();
        InkOut();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
