using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // [SerializeField] private Rigidbody2D rb;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private float moveInput;
    private float moveSpeed = 5f;
    private float jumpInput;
    private float jumpForce = 10f;
    private bool isGrounded;
    // public Transform feetPos;
    // public float circleRadius;
    // public LayerMask ground;

    // public float jumpTime;
    // private float jumpTimeCounter;
    // private bool isJumping;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // circleRadius = 0.5f;

        // jumpTime = 1;
        // jumpTimeCounter = 0;

        // isGrounded = true;
        // isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump(isGrounded);

        // isGrounded = Physics2D.OverlapCircle(feetPos.position,
        //     circleRadius);
        // Jump(isGrounded);

        // Debug.Log(ground);
        // Debug.Log(isGrounded);
    }
    private void Turn()
    {
        if (moveInput > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        moveInput = Mathf.Min(moveInput, moveSpeed);
        // rb.velocity = new Vector2(xAxis * moveSpeed, rb.velocity.y);
        // moveInput = Input.GetAxis("Horizontal");
        Turn();
        // velocity = new Vector2(moveInput * moveSpeed, velocity.y);
    }

    private void Jump(bool isGrounded)
    {
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpInput++;
                jumpInput = Mathf.Min(jumpInput, 1);
            }
        }
        else
        {
            jumpInput--;
            jumpInput = Mathf.Max(jumpInput, 0);
        }
        // if (isGrounded == true && Input.GetButtonDown("Jump"))
        // {
        //     isJumping = true;
        //     jumpTimeCounter = jumpTime;
        //     velocity = new Vector2(velocity.x, jumpForce);
        // }
        // if (isJumping == true && Input.GetButtonDown("Jump"))
        // {
        //     // isGrounded = false;
        //     if (jumpTimeCounter > 0)
        //     {
        //         velocity = new Vector2(velocity.x, jumpForce);
        //         jumpTimeCounter -= Time.deltaTime;
        //     }
        //     else if (jumpTimeCounter < 0)
        //     {
        //         isJumping = false;
        //     }
        // }
        // if (Input.GetButtonUp("Jump"))
        // {
        //     isJumping = false;
        // }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector2(rb.position.x + moveInput * moveSpeed * Time.fixedDeltaTime,
            rb.position.y + jumpInput * jumpForce * Time.fixedDeltaTime));
    }
}
