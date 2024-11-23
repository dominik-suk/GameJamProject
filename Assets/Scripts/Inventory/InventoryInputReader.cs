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

    public void OnChangeItem(InputAction.CallbackContext context)
    {
        Debug.Log("Change Item");
        Inventory.Instance.ChangeSelectedItem(1);
    }

    public void OnUseItem(InputAction.CallbackContext context)
    {
        Debug.Log("Use Item");
        Inventory.Instance.CurrentItem.Use();
    }
}