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
    AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        visuals = animator.gameObject;
        audioSource = GetComponent<AudioSource>();
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
        audioSource.enabled = true;
    }

    public void Stop()
    {
        animator.SetBool("Run", false);
        audioSource.enabled = false;
    }

    public void GoToID(TriggerFunctionality destination)
    {
        //Debug.Log("ID actual: " + currentID + "\nID objetivo: " + destination.id + "\nDiferencia: " + (destination.id - currentID));
        if (destination.id - currentID > 1)
        {
            transform.position = objective;
        }
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
