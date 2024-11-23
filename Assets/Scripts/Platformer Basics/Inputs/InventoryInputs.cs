using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InventoryInputs : MonoBehaviour, Controls.IInventoryActions
{
    [SerializeField] private UnityEvent<int> changeItemEvent;
    [SerializeField] private UnityEvent useItemEvent;
    public void OnChangeItem(InputAction.CallbackContext context)
    {
        int value = (int) context.ReadValue<Vector2>().y;
        changeItemEvent.Invoke(value);
    }

    public void OnUseItem(InputAction.CallbackContext context)
    {
        if(context.started) useItemEvent.Invoke();
    }
}