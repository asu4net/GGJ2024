using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    float horizontal;
    public float speed = 5f;
    bool isFacingRight = true;
    public GameObject visuals;
    public Animator anim;

    Rigidbody2D rb;
    LadderMovement lm;
    AudioManager am;
    [HideInInspector]
    public FootstepsScript fs;

    public bool canPlay = false;

    private void Awake()
    {
        lm = GetComponent<LadderMovement>();
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<AudioManager>();
        fs = GetComponent<FootstepsScript>();
    }

    void Update()
    {
        if (canPlay)
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
    }
    private void FixedUpdate()
    {
        if (canPlay)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if(Mathf.Abs(rb.velocity.x)>0 && rb.velocity.y==0)
            {
                fs.PlayFootsteps();
            }
            else
            {
                fs.StopFootsteps();
            }
        }
    }
    public void SwitchPlayerState()
    {
        canPlay = !canPlay;
    }

    public void Flip()
    {
        if(!lm.isClimbing &&(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0))
        {
            isFacingRight=!isFacingRight;
            Quaternion localRotation=visuals.transform.rotation;
            Debug.Log("Rotación actual: " + localRotation.y);
            localRotation.y *= -1;
            Debug.Log("Rotación a aplicar: " + localRotation.y);
            visuals.transform.rotation = localRotation;
            Debug.Log("Rotación actual (nueva): " + visuals.transform.rotation.y);
        }
        
        else if(lm.isClimbing && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Quaternion localRotation = visuals.transform.rotation;
            localRotation.y *= -1;
            visuals.transform.rotation = localRotation;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AudioTrigger"))
        {
            am.LoadPlaylist(collision.GetComponent<TriggerFunctionality>());
            if(collision.GetComponent<TriggerFunctionality>().brother != null)
            {
                collision.GetComponent<TriggerFunctionality>().brother.SetActive(false);
            }
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Chest"))
        {
            collision.gameObject.GetComponent<TriggerFunctionality>().Director.gameObject.GetComponent<Animator>().enabled = true;
            collision.gameObject.GetComponent<TriggerFunctionality>().Director.gameObject.GetComponent<Animator>().SetBool("Go",true);
            collision.gameObject.SetActive(false);
        }
    }
}
