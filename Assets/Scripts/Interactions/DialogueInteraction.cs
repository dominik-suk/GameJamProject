using System;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteraction : MonoBehaviour, IInteractable {
    [Header("Settings")]
    [SerializeField] private Dialogue dialogue;
    [Header("Events")]
    [SerializeField] private UnityEvent interactEvent;
    [SerializeField] private UnityEvent dialogueInteractionEvent;
    public static Action<Dialogue> dialogueFinishedEvent;

    public void Interact()
    {
        dialogueFinishedEvent?.Invoke(dialogue);
        interactEvent?.Invoke();
        DialogueDisplay.OnDialogueFinished += DialogueFinished;
    }

    private void DialogueFinished()
    {
        DialogueDisplay.OnDialogueFinished -= DialogueFinished;
        dialogueInteractionEvent?.Invoke();
    }
}