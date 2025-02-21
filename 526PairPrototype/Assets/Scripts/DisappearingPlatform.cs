using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    // Time before the platform disappears
    public float disappearTime = 2f;
    // Time before the platform reappears
    public float reappearTime = 3f;

    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Start the disappearing and reappearing cycle when the game starts
        StartCoroutine(DisappearAndReappearCycle());
    }

    private IEnumerator DisappearAndReappearCycle()
    {
        while (true)
        {
            boxCollider.enabled = true;
            spriteRenderer.enabled = true;

            yield return new WaitForSeconds(disappearTime);

            boxCollider.enabled = false;
            spriteRenderer.enabled = false;

            yield return new WaitForSeconds(reappearTime);
        }
    }
}
