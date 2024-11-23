using System;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteraction : MonoBehaviour, IInteractable {
    [Header("Settings")]
    [SerializeField] private Dialogue dialogue;
    [Header("Events")]
    [SerializeField] private UnityEvent interactEvent;
    public static Action<Dialogue> OnDialogueInteraction;

    public void Interact()
    {
        OnDialogueInteraction?.Invoke(dialogue);
        interactEvent?.Invoke();
    }
}