using System;
using UnityEngine;

public class GroundedChecker2D : MonoBehaviour {
    [SerializeField] private Collider2D groundedCollider;
    [SerializeField] private LayerMask layerMask;
    public Action<GameObject> OnGrounded;
    public Action<GameObject> OnLeaveGround;
    public bool IsGrounded {get;private set;}
    private void OnTriggerEnter2D(Collider2D other) {
        if(!groundedCollider.IsTouchingLayers(layerMask)) return;
        IsGrounded = true;
        OnGrounded?.Invoke(gameObject);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(groundedCollider.IsTouchingLayers(layerMask)) return;
        IsGrounded = false;
        OnLeaveGround?.Invoke(gameObject);
    }    
}