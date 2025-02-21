using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player.instance.Win();
    }
}
