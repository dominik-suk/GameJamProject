using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InventoryInputReader : MonoBehaviour, Controls.IInventoryActions
{
    [Header("Events")]
    [SerializeField] private UnityEvent<Vector2> ScrollEvent;

    private Controls controls;
    private void OnEnable() {
        controls = new Controls();
        controls.Inventory.Enable();
        controls.Inventory.AddCallbacks(this);        
    }
    private void OnDisable() {
        controls.Inventory.RemoveCallbacks(this);
        controls.Inventory.Disable();
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        ScrollEvent?.Invoke(context.ReadValue<Vector2>());
    }
}