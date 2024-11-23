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


    Vector2 BounceVelocity;
    float bounceDecreaseFactor;
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
    public void HandleCancelJump()
    {
        StartCoroutine(TryCancelJump());
    }
    private IEnumerator TryJump()
    {
        float timer = 0;
        while(timer < inputBuffer)
        {
            if(groundedChecker.IsGrounded)
            {
                jumpCount = 0;
                Jump();
                yield break;
            }
            if (jumpCount < jumpStrengt.Length)
            {
                Jump();
                yield break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator TryCancelJump()
    {
        while(rb.linearVelocityY > 0)
        {
            rb.linearVelocityY *= 0.5f;
            yield return null;
        }
    }

    public void Bounce(Vector2 up, float force, float decreaser = 0.5f)
    {
        BounceVelocity = up * force;
        bounceDecreaseFactor = decreaser;
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
        BounceVelocity = Vector2.Lerp(BounceVelocity, Vector2.zero, bounceDecreaseFactor);
        jumpCount++;
        StopAllCoroutines();
        OnJump?.Invoke();
    }
}