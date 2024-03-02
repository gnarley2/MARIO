using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float EnemySpeed = 1f;
    public new Rigidbody2D rb;

    private Vector2 velocity;
    public Vector2 direction = Vector2.left;

    // Start is called before the first frame update
    void Awake()
    {
        enabled = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //  velocity.x = direction.x * EnemySpeed;
        //  velocity.y = Physics2D.gravity.y;
        //// rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        rb.velocity = -transform.right * EnemySpeed;

    }

    private void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        rb.WakeUp();
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.Sleep();
    }



}
