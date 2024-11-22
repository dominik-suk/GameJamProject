using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlatformerInputReader", menuName = "PlatformerInputReader", order = 0)]
public class PlatformerInputReader : MonoBehaviour, Controls.IPlatformerActions
{
    [Header("Events")]
    [SerializeField] public UnityEvent<Vector2> MoveEvent;
    [SerializeField] public UnityEvent JumpEvent;
    [SerializeField] public UnityEvent InteractEvent;
    private Controls controls;
    private void OnEnable() {
        controls = new Controls();
        controls.Platformer.Enable();
        controls.Platformer.AddCallbacks(this);        
    }
    private void OnDisable() {
        controls.Platformer.RemoveCallbacks(this);
        controls.Platformer.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        InteractEvent?.Invoke();
    }
}


