using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // [SerializeField] private Rigidbody2D rb;
    private Rigidbody2D rb;

    private Vector2 velocity;
    private float moveInput;
    private float jumpForce = 9f;
    private float moveSpeed = 5f;

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
        // float xAxis = Input.GetAxis("Horizontal");
        // rb.velocity = new Vector2(xAxis * moveSpeed, rb.velocity.y);
        moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        position += velocity * Time.fixedDeltaTime;

        rb.MovePosition(position);
    }
}
