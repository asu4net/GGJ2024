using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    float vertical;
    public float climbSpeed = 8f;
    bool isLadder;
    bool isClimbing;

    [SerializeField] Rigidbody2D rb;

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
            Debug.Log("Aqu� estoy");
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbSpeed);
            Debug.Log("Subimos a una velocidad de " + vertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = 4f;
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
