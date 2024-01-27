using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    float horizontal;
    public float speed = 5f;
    bool isFacingRight = true;
    public GameObject visuals;

    Rigidbody2D rb;
    public Animator anim;

    LadderMovement lm;

    private void Awake()
    {
        lm = GetComponent<LadderMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) > 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    public void Flip()
    {
        if(!lm.isClimbing &&(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0))
        {
            isFacingRight=!isFacingRight;
            Quaternion localRotation=visuals.transform.rotation;
            localRotation.y *= -1;
            visuals.transform.rotation = localRotation;
        }
        
        else if(lm.isClimbing && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Quaternion localRotation = visuals.transform.rotation;
            localRotation.y *= -1;
            visuals.transform.rotation = localRotation;
        }

    }
}
