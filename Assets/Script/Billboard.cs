using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject child;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "V_Billboard")
        {
            //If under distance, set child be true
            float distance = Vector3.Distance(PlayerData.instance.transform.position, transform.position);
            if (distance < 4)
            {
                if (gameObject.name != "CanvasPlayer") child.SetActive(true);
                Vector3 targetDirection = Camera.main.transform.position - transform.position;
                targetDirection.y = 0f;
                transform.rotation = Quaternion.LookRotation(targetDirection);
            }
            else
            {
                if (gameObject.name != "CanvasPlayer") child.SetActive(false);
            }
        }
        else
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
