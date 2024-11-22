using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Rigidbody2DJump : MonoBehaviour {
    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GroundedChecker2D groundedChecker;

    [Header("Settings")]
    [Tooltip("The number of jumps is based on the number of jumpStrengths")]
    [SerializeField] float[] jumpStrengt = {10};
    [SerializeField] float coyoteTime = .1f;
    [SerializeField] float inputBuffer = .1f;
    int jumpCount = 0;
    public Action OnJump;
    private void OnEnable() {
        groundedChecker.OnGrounded += ResetJump;
        groundedChecker.OnLeaveGround += StartCoyoteTimer;
    }
    private void OnDisable() {
        groundedChecker.OnGrounded -= ResetJump;
        groundedChecker.OnLeaveGround -= StartCoyoteTimer;
        StopAllCoroutines();
    }
    private void ResetJump(GameObject gameObject)
    {
        jumpCount = 0;
    }
    private void StartCoyoteTimer(GameObject gameObject)
    {
        if(jumpCount == 0 && gameObject.activeInHierarchy)
        {
            StartCoroutine(CoyoteTimerRoutine());
        }
    }
    public void HandleJump()
    {
        StartCoroutine(TryJump());
    }
    private IEnumerator TryJump()
    {
        float timer = 0;
        while(timer < inputBuffer)
        {
            if(groundedChecker.IsGrounded ||  jumpCount < jumpStrengt.Length)
            {
                Jump();
                yield break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator CoyoteTimerRoutine()
    {
        float timer = coyoteTime;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        jumpCount++;
    }
    private void Jump()
    {
        Vector2 newVelocity = rb.linearVelocity;
        newVelocity.y = jumpStrengt[jumpCount];
        rb.linearVelocity = newVelocity;
        jumpCount++;
        StopAllCoroutines();
        OnJump?.Invoke();
    }
}