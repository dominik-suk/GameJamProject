using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    [SerializeField] private Dialogue currentDialogue;
    private int dialogueIndex;
    public void SetDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        dialogueIndex = 0;
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