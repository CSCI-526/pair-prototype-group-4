using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public bool isDestroyed = false;
    public Collider2D collider;

    public static List<Breakable> breakables = new List<Breakable>();

    private void Awake()
    {
        breakables.Add(this);
    }

    private void OnDestroy()
    {
        breakables.Remove(this);
    }

    public void DestroyBreakable()
    {
        isDestroyed = true;

        foreach (Breakable breakable in GetAdjacentBreakables())
        {
            breakable.DestroyBreakable();
        }

        collider.enabled = false;
        Destroy(gameObject);
    }

    public List<Breakable> GetAdjacentBreakables()
    {
        List<Breakable> adjacentBreakables = new List<Breakable>();

        float leftEdge = transform.position.x - collider.bounds.size.x / 2;
        float rightEdge = transform.position.x + collider.bounds.extents.x;
        float topEdge = transform.position.y + collider.bounds.extents.y;
        float bottomEdge = transform.position.y - collider.bounds.extents.y;

        foreach (Breakable breakable in breakables)
        {
            if (breakable == this || breakable.isDestroyed) continue;

            float otherLeftEdge = breakable.transform.position.x - breakable.collider.bounds.extents.x;
            float otherRightEdge = breakable.transform.position.x + breakable.collider.bounds.extents.x;
            float otherTopEdge = breakable.transform.position.y + breakable.collider.bounds.extents.y;
            float otherBottomEdge = breakable.transform.position.y - breakable.collider.bounds.extents.y;

            if (leftEdge <= otherRightEdge && rightEdge >= otherLeftEdge && topEdge >= otherBottomEdge && bottomEdge <= otherTopEdge)
            {
                adjacentBreakables.Add(breakable);
            }
        }

        return adjacentBreakables;
    }
}
