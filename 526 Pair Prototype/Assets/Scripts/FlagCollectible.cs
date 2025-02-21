using UnityEngine;

public class FlagCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Flag Collected!");
            FlagManager.instance.AddFlag();  // Increase flag count
            Destroy(gameObject);  // Remove the flag
        }
    }
}
