using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [Header("References")]
    [SerializeField] new private Collider2D collider;
    private List<IInteractable> interactables = new();
    public event Action OnInteractionsAvailable;
    public event Action OnInteractionsUnavailable;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if(interactables.Contains(interactable)) return;
            if(interactables.Count == 0)
            {
                OnInteractionsAvailable?.Invoke();
            }
            interactables.Add(interactable);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(interactables.Contains(other.gameObject.GetComponent<IInteractable>()))
        {
            interactables.Remove(other.gameObject.GetComponent<IInteractable>());
            if(interactables.Count == 0)
            {
                OnInteractionsUnavailable?.Invoke();
            }
        }
    }
    public void Interact()
    {
        foreach(IInteractable interactable in interactables)
        {
            interactable.Interact();
        }
    }
}