using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xAxis * 5f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
                rb.velocity = new Vector2(rb.velocity.x, 9f);
    }
}