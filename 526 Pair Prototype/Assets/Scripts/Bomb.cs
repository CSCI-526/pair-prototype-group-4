using UnityEngine;

public class Bomb : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Breakable breakable = collision.gameObject.GetComponent<Breakable>();
        if (breakable)
        {
            breakable.DestroyBreakable();
        }

        Explode();
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
