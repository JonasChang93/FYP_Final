using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius = 3.0f;
    public float interactionAngle = 60f;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerData.instance.transform.Find("ModelBox");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        Vector3 objectDir = Vector3.Normalize(transform.position - player.position);
        Vector3 playerDir = player.forward;
        objectDir.y = 0;
        playerDir.y = 0;
        float cosAngle = Vector3.Angle(objectDir, playerDir);

        if (Input.GetKeyDown(KeyCode.E) && distance < interactionRadius && cosAngle < interactionAngle)
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
