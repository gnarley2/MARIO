using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // private float Horizontal;
    //private float speed = 8f;
    //private float jumpingPower = 16f;
    //private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform groundCheck;
    //[SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
                rb.velocity = new Vector3(0, 5f, 0);
    }
}
