using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    private PlayerSpriteRenderer activeRenderer;

    public CapsuleCollider2D capsuleCollider2D { get; private set; }

    public bool big => bigRenderer.enabled;
    // public bool small => smallRenderer.enabled;

    private void Awake()
    {
        // TODO
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        activeRenderer = smallRenderer;
    }

    public void Hit()
    {
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }
    }

    public void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;
        activeRenderer = smallRenderer;

        // Downsize and center big mario's capsule collider to fit
        // small mario
        capsuleCollider2D.size = Vector2.one;
        capsuleCollider2D.offset = Vector2.zero;

        StartCoroutine(ScaleAnimation());
    }

    public void Grow()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
        activeRenderer = bigRenderer;

        // Enlarge and offset small mario's capsule collider to fit
        // big mario
        capsuleCollider2D.size = new Vector2(1f, 2f);
        capsuleCollider2D.offset = new Vector2(0, 0.5f);

        StartCoroutine(ScaleAnimation());
    }

    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                smallRenderer.enabled = !smallRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }

            yield return null;
            // yield return new WaitForSeconds(((1 * duration) * Time.captureFramerate)/4);
        }

        smallRenderer.enabled = false;
        bigRenderer.enabled = false;
        activeRenderer.enabled = true;
    }

    private void Death()
    {
        // TODO
    }
}
