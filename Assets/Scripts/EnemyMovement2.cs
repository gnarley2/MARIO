using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{

    public float MovementSpeed = 3.0f;
    public bool btravellingRight = true;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    float FallSpeed = 10.0f;
    
    void Awake()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer.flipX = btravellingRight;
        enabled = false;
    }

    void Update()
    {
       Vector3 direction = (btravellingRight) ? transform.right : -transform.right;
       direction *= Time.deltaTime * MovementSpeed;

      if (enabled)
       {
            //Horizontal movement - is continuous
           transform.Translate(direction);
            //Turn around when hit pipe or ground
           TransformFlip();
            // fall when walk off edge
           GroundCheck();
       }
    }

    private void TransformFlip()
    { 
        float Distance = 0.5f;
        Vector3 rayDirection = (btravellingRight) ? Vector3.right : Vector3.left;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayDirection * Distance - new Vector3(0f, 0.25f, 0f), rayDirection, 0.075f);

        if (hit.collider != null)
        {
            if (hit.transform.tag == "Pipe" || hit.transform.tag == "Ground")
            {
                btravellingRight = !btravellingRight;
                SpriteRenderer.flipX = btravellingRight;

            }
        }
    }
    private void GroundCheck()
    {
        float distance = 0.2f;
        Vector3 rayDirection = Vector3.down;  // Always points straight down

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayDirection * distance - new Vector3(0f, 0.25f, 0f), rayDirection, 0.075f);

        if (hit.collider == null || hit.transform.tag != "Ground")
        {
            // No ground detected, move downward
            float verticalMovement = -FallSpeed * Time.deltaTime;
            transform.position += new Vector3(0f, verticalMovement, 0f);
        }
    }


    //Set Movement for only when Enemy is Rendered
    void OnBecameVisible()
    {
        enabled = true;
    }
     void OnBecameInvisible()
    {
        enabled = false;
    }

    void OnEnable()
    {
        enabled = true;
    }
    void OnDisable()
    {
        enabled = false;
    }

}
