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
    public void HandleMovement(Vector2 vector)
    {
        desiredDirection = vector;
    }
    private void Update() {
        Vector2 newVelocity = Vector2.MoveTowards(rb.linearVelocity,desiredDirection*moveSpeed, moveSpeed/speedUpTime * Time.deltaTime);
        if(!horizontalMovement)
        {
            newVelocity.y = rb.linearVelocity.y;
        }
        rb.linearVelocity = newVelocity;
    }

}