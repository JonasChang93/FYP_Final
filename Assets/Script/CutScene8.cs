using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CutScene8 : MonoBehaviour
{
    PlayerController playerController;
    public GameObject enemyType4Enter;
    public GameObject enemyType4;
    public GameObject cutScene8;

    public Transform camZ;
    public Text Popup;
    public PlayableDirector playableDirector;

    // Start is called before the first frame update
    void Start()
    {
        playerController = PlayerData.instance.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playableDirector.gameObject.SetActive(true);
        playableDirector.Play();
        Popup.text = "TENGU";

        playerController.enabled = false;
        playerController.transform.position = transform.position + new Vector3(5, 0, 5);

        camZ.localRotation = Quaternion.identity;
        camZ.parent.localRotation = Quaternion.identity;
        playerController.rotationX = 0;
    }

    public void CutScene8End()
    {
        playerController.enabled = true;
        enemyType4Enter.SetActive(false);
        enemyType4.SetActive(true);
        cutScene8.SetActive(false);
    }
}