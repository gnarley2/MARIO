using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;

    public bool big => bigRenderer.enabled;
    public bool small => smallRenderer.enabled;

    private void Awake()
    {

    }

    private void Grow()
    {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
    }
}
