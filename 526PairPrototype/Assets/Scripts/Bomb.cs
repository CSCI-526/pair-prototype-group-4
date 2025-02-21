using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float minDistanceForLaunch = 8f;
    public Player player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Breakable breakable = other.gameObject.GetComponent<Breakable>();
        if (breakable != null)
        {
            breakable.DestroyBreakable();
            Explode();
        }
    }

    public void Explode()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance < minDistanceForLaunch)
        {
            player.LaunchPlayer(direction, 1);
        }

        Destroy(gameObject);
    }
}
