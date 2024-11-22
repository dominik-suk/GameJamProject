using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlatformerInputReader", menuName = "PlatformerInputReader", order = 0)]
public class PlatformerInputReader : ScriptableObject, Controls.IPlatformerActions
{
    public Action<Vector2> MoveEvent;
    public Action JumpEvent;
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
}


