using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal;
    public float speed = 8f;
    bool isFacingRight = true;

    [SerializeField] Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    public void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight=!isFacingRight;
            Vector3 localscale=transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }
}
