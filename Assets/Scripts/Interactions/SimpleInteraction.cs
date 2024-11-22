using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : MonoBehaviour, IInteractable
{
    [Header("Events")]
    [SerializeField] private UnityEvent interactEvent;
    public void Interact()
    {
        interactEvent?.Invoke();
    }
}