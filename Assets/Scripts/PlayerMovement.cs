using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // [SerializeField] private Rigidbody2D rb;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xAxis * 5f, rb.velocity.y);
    }
    
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 9f);
        }
    }
}
