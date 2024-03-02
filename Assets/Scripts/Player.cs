using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public PlayerSpriteRenderer activeRenderer;

    private CapsuleCollider2D capsuleCollider2D;

    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;

    private void Awake()
    {
        // TODO
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    public void Hit()
    {
        if (big)
        {
            Shrink();
        }else{
            Death();
        }
    }

    private void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;
        activeRenderer = smallRenderer;

        // Downsize and center big mario's capsule collider to fit
        // small mario
        capsuleCollider2D.size = Vector2.one;
        capsuleCollider2D.offset = Vector2.zero;
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
    }

    private void Death()
    {
        // TODO
    }
}
