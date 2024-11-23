using System;
using System.Collections;
using UnityEngine;

public class MoveRigidbody2D : MonoBehaviour {
    [Header("References")]
    [SerializeField] Rigidbody2D rb;

    [Header("Settings")]
    [SerializeField] bool horizontalMovement = false;
    [SerializeField] float speedUpTime;
    [SerializeField] float moveSpeed = 10;
    Vector2 desiredDirection;

    Vector2 DashVelocity;
    public void HandleMovement(Vector2 vector)
    {
        desiredDirection = vector;
    }

    public void HandleDash()
    {
        Debug.Log("DASH");
        DashVelocity = desiredDirection.normalized * 20.0f;
    }

    private void Update() {
        Vector2 newVelocity = Vector2.MoveTowards(rb.linearVelocity,desiredDirection*moveSpeed, moveSpeed/speedUpTime * Time.deltaTime);
        if(!horizontalMovement)
        {
            newVelocity.y = rb.linearVelocity.y;
        }
        rb.linearVelocity = newVelocity + DashVelocity;
        DashVelocity = Vector2.Lerp(DashVelocity, Vector2.zero, 0.5f);
    }

}