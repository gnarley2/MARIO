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
        // TODO
    }

    public void Grow()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
        activeRenderer = bigRenderer;

        capsuleCollider2D.size = new Vector2(1f, 2f);
    }

    private void Death()
    {
        // TODO
    }
}
