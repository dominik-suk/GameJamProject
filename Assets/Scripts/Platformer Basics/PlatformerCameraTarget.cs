using Unity.VisualScripting;
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
        float distanceToPlayer = (transform.position - parent.transform.position).magnitude;
        if (groundedChecker.IsGrounded)
        {
            lastYPos = parent.position.y;
        }
        else
        {
            newPosition.y = lastYPos;
            if(distanceToPlayer > 2)
            {
                lastYPos = Vector2.Lerp(new Vector2(parent.position.x, lastYPos), parent.position, 0.5f).y;
            }
        }

        transform.position = newPosition;
    }
}