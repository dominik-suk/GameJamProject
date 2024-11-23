using System;
using UnityEngine;
using UnityEngine.Events;

public class ReactToDialogueStarted : MonoBehaviour {
    [Header ("Events")]
    [SerializeField] private UnityEvent onDialogueStarted;
    [SerializeField] private UnityEvent onDialogueFinished;
    private void OnEnable() {
        DialogueDisplay.OnDialogueStarted += OnDialogueStarted;
        DialogueDisplay.OnDialogueFinished += OnDialogueFinished;
    }

    private void OnDisable() {
        DialogueDisplay.OnDialogueStarted -= OnDialogueStarted;
        DialogueDisplay.OnDialogueFinished -= OnDialogueFinished;
    }

    private void OnDialogueFinished()
    {
        onDialogueFinished?.Invoke();
    }
    private void OnDialogueStarted()
    {
        onDialogueStarted?.Invoke();
    }
}