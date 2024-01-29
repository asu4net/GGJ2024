using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ButtMovement : MonoBehaviour
{
    public float speed = 8;
    public int currentID = 0;
    [HideInInspector]
    public bool canMove = false;
    bool isFacingRight = true;

    Animator animator;
    GameObject visuals;
    Rigidbody2D rb;
    Vector3 objective;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        visuals = animator.gameObject;
    }

    private void Update()
    {
        if (canMove)
        {
            Walk();
            transform.position = Vector3.MoveTowards(transform.position, objective, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, objective) < 0.4)
            {
                Stop(); 
                canMove = false;
            }
        }
        Flip();
    }

    public void Walk()
    {
        animator.SetBool("Run", true);
    }

    public void Stop()
    {
        animator.SetBool("Run", false);
    }

    public void GoToID(TriggerFunctionality destination)
    {
        objective = destination.gameObject.transform.position;
        currentID = destination.id;
        canMove = true;
    }

    public void Flip()
    {
        float posCheck = objective.x - transform.position.x;
        if(isFacingRight && posCheck < 0 || !isFacingRight && posCheck > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 newScale =visuals.transform.localScale;
            newScale.x *= -1;
            visuals.transform.localScale = newScale;
        }
    }

}
