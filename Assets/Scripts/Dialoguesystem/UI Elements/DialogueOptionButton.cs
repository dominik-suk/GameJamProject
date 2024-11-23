using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueOptionButton : MonoBehaviour {
    [Header("References")]
    [SerializeField] TMP_Text optionTextLocalized;
    [SerializeField] private TMP_Text optionText;
    [SerializeField] private Image optionImage;
    private DialogueReader dialogueManager;
    private DialogueDisplay dialogueDisplay;
    private Dialogue.Option option;
    public static Action OnSelected;
    public void Init(Dialogue.Option option, Speaker speaker, DialogueReader dialogueManager, DialogueDisplay dialogueDisplay)
    {
        optionTextLocalized.text = option.optionText;
        optionImage.color = speaker.TextColor;
        this.option = option;
        this.optionText.color = speaker.BackgroundColor;
        this.dialogueManager = dialogueManager;
        this.dialogueDisplay = dialogueDisplay;
    }
    private void OnEnable() {
        OnSelected += DestroSelf;
    }
    private void OnDisable() {
        OnSelected -= DestroSelf;
        Destroy(gameObject);
    }

    private void DestroSelf()
    {
        Destroy(gameObject);
    }

    public void SelectOption()
    {
        Debug.Log("Selected Option");
        dialogueManager.SetDialogue(option.nextDialogueBranch);
        dialogueDisplay.NextLine();
        OnSelected?.Invoke();
    }
}