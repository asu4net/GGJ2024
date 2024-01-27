using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    float vertical;
    public float climbSpeed = 4f;
    bool isLadder;
    [HideInInspector]
    public bool isClimbing;

    Rigidbody2D rb;
    public Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        

        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            anim.SetBool("climb", true);
            
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
            if (rb.velocity == Vector2.zero)
            {
                anim.SetBool("climbstop", true);
            }
            else
            {
                anim.SetBool("climbstop", false);
            }
        }
        else
        {
            anim.SetBool("climb", false);
            anim.SetBool("climbstop", false);
            rb.gravityScale = 4f;

            if (rb.velocity.y < 0)
            {
                anim.SetBool("fall", true);
            }
            else
            {
                anim.SetBool("fall", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder= false;
            isClimbing = false;
        }
    }
}
