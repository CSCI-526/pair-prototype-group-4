using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool followX = true, followY = true;

    void Update()
    {
        if (target)
        {
            Vector3 prevPosition = transform.position;
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
            if (!followX)
            {
                transform.position = new Vector3(prevPosition.x, transform.position.y, transform.position.z);
            }
            if (!followY)
            {
                transform.position = new Vector3(transform.position.x, prevPosition.y, transform.position.z);
            }
        }
    }
}
