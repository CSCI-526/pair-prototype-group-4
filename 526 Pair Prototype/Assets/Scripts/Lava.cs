using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    void Update()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
}
