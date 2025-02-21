using UnityEngine;

public class Bomb : MonoBehaviour
{
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
        player.LaunchPlayer(direction, 1);

        Destroy(gameObject);
    }
}
