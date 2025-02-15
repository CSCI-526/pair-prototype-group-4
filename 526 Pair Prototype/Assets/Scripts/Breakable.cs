using System.Collections;
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
        GetComponent<Collider2D>().enabled = false;

        foreach (Breakable breakable in GetAdjacentBreakables())
        {
            breakable.DestroyBreakable();
        }

        Destroy(gameObject);
    }

    public List<Breakable> GetAdjacentBreakables()
    {
        List<Breakable> adjacentBreakables = new List<Breakable>();

        foreach (Breakable breakable in breakables)
        {
            if (breakable == this) continue;

            if (Mathf.Abs(breakable.transform.position.x - transform.position.x) <= 0.1f && Mathf.Abs(breakable.transform.position.y - transform.position.y) <= 0.1f)
            {
                adjacentBreakables.Add(breakable);
            }
        }

        return adjacentBreakables;
    }
}
