using UnityEngine;
using UnityEngine.Events;

public class DialogueReader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Dialogue currentDialogue;
    [Header("Events")]
    [SerializeField] private UnityEvent onNewDialogueSet;
    private int dialogueIndex;
    private void OnEnable() {
        DialogueInteraction.OnDialogueInteraction += SetDialogue;
    }
    private void OnDisable() {
        DialogueInteraction.OnDialogueInteraction -= SetDialogue;
    }
    public void SetDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        dialogueIndex = 0;
        onNewDialogueSet?.Invoke();
    }
    public Dialogue.Line ReadDialogueLine()
    {
        if(currentDialogue != null && dialogueIndex < currentDialogue.DialogueLines.Length)
        {
            dialogueIndex++;
            return currentDialogue.DialogueLines[dialogueIndex - 1];
        }
        else
        {
            return null;
        }
    }
    public Dialogue.Option[] ReadDialogueOptions()
    {
        return currentDialogue.DialogueOptions;
    }
    public bool IsLastline()
    {
        return dialogueIndex == currentDialogue.DialogueLines.Length;
    }
    public bool HasOptions()
    {
        if(currentDialogue == null) return false;
        return currentDialogue.DialogueOptions.Length > 0;
    }
}