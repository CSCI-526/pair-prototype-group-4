using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Player player;

    public void Explode()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        player.LaunchPlayer(direction, 1);

        Destroy(gameObject);
    }
}
