using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public float speed = 3f; // Speed of the ball
    public float leftLimit = -7f; // Left boundary
    public float rightLimit = 7f; // Right boundary

    private int direction = 1; // 1 for right, -1 for left

    void Update()
    {
        // Move the ball
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // Change direction when reaching the limits
        if (transform.position.x >= rightLimit)
        {
            direction = -1; // Move left
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1; // Move right
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Died!");
            collision.GetComponent<Player>().Die(); // Call player's death function
        }
    }
}
