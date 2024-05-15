using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Vector3 origin;
    Vector3 direction;
    Vector3 hitPoint;

    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraTransform();
    }

    void CameraTransform()
    {
        origin = transform.parent.position + new Vector3(0, 1);
        direction = -transform.parent.forward;
        Ray ray = new Ray(origin, direction);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            hitPoint = hit.point;
        }
        if (hit.collider != null && transform.parent.InverseTransformPoint(hitPoint).z > -3)
        {
            transform.localPosition = new Vector3(0, 1, transform.parent.InverseTransformPoint(hitPoint).z);
        }
        else
        {
            transform.localPosition = new Vector3(0, 1, -3);
        }
    }
}