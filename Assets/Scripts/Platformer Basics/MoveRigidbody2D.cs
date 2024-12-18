using System;
using UnityEngine;

public class MoveRigidbody2D : MonoBehaviour {
    [Header("References")]
    [SerializeField] Rigidbody2D rb;

    [Header("Settings")]
    [SerializeField] bool horizontalMovement = false;
    [SerializeField] float speedUpTime;
    [SerializeField] float moveSpeed = 10;
    
    [Header("Animation Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [Header("Dash Settings")]
    [SerializeField] float dashForce = 20.0f;
    [SerializeField, Range(0.0f,1.0f)] float dashForceDecreaseSpeed = 0.5f;
    [SerializeField] int dashCount = 1;
    private int availableDashes = 1;
    Vector2 desiredDirection;


    Vector2 DashVelocity;
    public void HandleMovement(Vector2 vector)
    {
        desiredDirection = vector;
    }

    public void GainDash()
    {
        if (availableDashes < dashCount) 
        {
            availableDashes++;
        }
    }


    public void HandleDash()
    {
        if(availableDashes > 0)
        {
            availableDashes--;
            DashVelocity.x = desiredDirection.normalized.x * dashForce;
        }
    }
    private void Update() {
        Vector2 newVelocity = Vector2.MoveTowards(rb.linearVelocity,desiredDirection*moveSpeed, moveSpeed/speedUpTime * Time.deltaTime);
        if(!horizontalMovement)
        {
            newVelocity.y = rb.linearVelocity.y;
        }
        rb.linearVelocity = newVelocity + DashVelocity;
        DashVelocity = Vector2.Lerp(DashVelocity, Vector2.zero, dashForceDecreaseSpeed);
        animator.SetBool("isWalking", Mathf.Abs(rb.linearVelocity.x) > 0.1f);
        spriteRenderer.flipX = rb.linearVelocity.x < 0;
        animator.SetBool("isJumping", rb.linearVelocity.y > .1f);
        animator.SetBool("isFalling", rb.linearVelocity.y < -.1f);
    }

}