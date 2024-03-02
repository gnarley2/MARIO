using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalPlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axisX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
            rb.velocity = new Vector2(rb.velocity.x, 9f);
    }
}
