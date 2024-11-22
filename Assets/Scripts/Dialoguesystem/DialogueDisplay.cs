using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueDisplay: MonoBehaviour {
    [Header("References")]
    [SerializeField] private DialogueReader dialogueReader;
    [SerializeField] private Typewriter typewriter;
    [SerializeField] private Animator animator;
    [SerializeField] private DialogueOptionButton dialogueOptionPrefab;


    [Header("UI Elements")]
    [SerializeField] private TMP_Text nameLocalized;
    [SerializeField] private Typewriter dialogueLocalized;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image speakerImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image nameContainerImage;

    [Header("Settings")]
    [Tooltip("Wird ausgewählt, wenn kein Speaker angegeben wurde")]
    [SerializeField] private Speaker defaultSpeaker;
    [SerializeField] private float optionSpawnTime = 0.25f;
    public Action OnNextLine;
    private void SetDialogueUI(Dialogue.Line dialogueLine)
    {
        if(dialogueLine == null) 
        {
            Close();
            return;
        }
        nameLocalized.text = dialogueLine.Speaker.Name;
        dialogueLocalized.TypeMessage(dialogueLine.Text); 
        backgroundImage.color = dialogueLine.Speaker.BackgroundColor;
        nameContainerImage.color = dialogueLine.Speaker.TextColor;
        nameText.color = dialogueLine.Speaker.BackgroundColor;
        dialogueText.color = dialogueLine.Speaker.TextColor;
        speakerImage.sprite = dialogueLine.Speaker.Sprite;
        animator.SetTrigger("Next");

        if(dialogueReader.IsLastline())
        {
            StartCoroutine(SpawnDialogueOptions(dialogueReader.ReadDialogueOptions(), dialogueLine.Speaker));
        }
    }
    private IEnumerator SpawnDialogueOptions(Dialogue.Option[] options, Speaker speaker)
    {
        foreach(Dialogue.Option option in options)
        {
            yield return new WaitForSeconds(optionSpawnTime);
            DialogueOptionButton optionObject = Instantiate(dialogueOptionPrefab, transform);
            optionObject.Init(option, speaker, dialogueReader, this);
        }
    }
    public void NextLine()
    {
        if(typewriter.IsTyping)
        {
            typewriter.TypeInstant();
        }
        else
        {
            OnNextLine?.Invoke();
            SetDialogueUI(dialogueReader.ReadDialogueLine());
        }
    }
        private void Close()
    {
        if(!dialogueReader.HasOptions())
        {
            animator.SetTrigger("Close");
        }
    }
}