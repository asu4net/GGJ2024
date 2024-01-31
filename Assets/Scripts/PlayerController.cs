using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float horizontal;
    public float speed = 5f;
    bool isFacingRight = true;
    public GameObject visuals;
    public Animator anim;
    public ButtMovement butt;

    Rigidbody2D rb;
    LadderMovement lm;
    AudioManager am;
    AudioSource audioSource;
    [HideInInspector]
    public FootstepsScript fs;
    [HideInInspector]
    public bool canPlay = false;
    public MusicClass bgm;

    private void Awake()
    {
        lm = GetComponent<LadderMovement>();
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<AudioManager>();
        fs = GetComponent<FootstepsScript>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            canPlay = true;
            isFacingRight = false;
        }
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
        if (collision.CompareTag("buttCP"))
        {
            butt.GoToID(collision.gameObject.GetComponent<TriggerFunctionality>());
        }

        if (collision.CompareTag("End"))
        {
            //collision.gameObject.GetComponent<Animator>().SetBool("endgame",true);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            collision.GetComponent<EndManager>().CallPausePlay();
        }
    }
}
