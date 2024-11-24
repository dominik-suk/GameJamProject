using System.Collections;
using UnityEngine;

public class PeacefulCatMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float idleTimeMin = 1f;
    public float idleTimeMax = 3f;
    public float moveTimeMin = 1f;
    public float moveTimeMax = 3f;
    public float jumpForce = 5f;
    public float jumpChance = 0.1f;
    public Animator animator;
    public Rigidbody2D rb;

    private bool isMoving = true;
    private float currentMoveDirection = 1f;

    private void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        StartCoroutine(MovementBehavior());
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.right * (currentMoveDirection * moveSpeed * Time.deltaTime));

            animator.SetBool("isWalking", true);

            if (currentMoveDirection > 0) 
            {
                transform.localScale = new Vector3(-1, 1, 1); // Face right
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // Face left
            }

            if (Random.Range(0f, 1f) < jumpChance)
            {
                Jump();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private IEnumerator MovementBehavior()
    {
        while (true)
        {
            isMoving = Random.Range(0f, 1f) > 0.2f;

            if (isMoving)
            {
                float moveDuration = Random.Range(moveTimeMin, moveTimeMax);
                yield return new WaitForSeconds(moveDuration);

                currentMoveDirection = Random.Range(0f, 1f) > 0.5f ? 1f : -1f;
            }
            else
            {
                float idleDuration = Random.Range(idleTimeMin, idleTimeMax);
                yield return new WaitForSeconds(idleDuration);
            }
        }
    }
}
