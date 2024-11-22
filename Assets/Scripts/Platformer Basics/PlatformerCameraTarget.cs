using UnityEngine;

public class PlatformerCameraTarget : MonoBehaviour {
    [SerializeField] Transform parent;
    [SerializeField] GroundedChecker2D groundedChecker;
    private float lastYPos;
    private void Start() {
        lastYPos = parent.position.y;
    }
    private void Update() {
        Vector2 newPosition = parent.position;
        if(groundedChecker.IsGrounded)
        {
            lastYPos = parent.position.y;
        }
        else
        {
            newPosition.y = lastYPos;
        }
        
        transform.position = newPosition;
    }
}