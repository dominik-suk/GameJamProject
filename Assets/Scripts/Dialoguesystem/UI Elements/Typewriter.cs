using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Typewriter : MonoBehaviour {
    [Header("References")]
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [Header("Settings")]
    [SerializeField] private float typingSpeed;
    public bool IsTyping {get; private set;} = false;

    private string currentMessage;
    public void TypeMessage(string message)
    {
        currentMessage = message;
        StopAllCoroutines();
        StartCoroutine(Type(message));
    }
    private IEnumerator Type(string message)
    {
        IsTyping = true;
        textMeshProUGUI.text = "";
        for(int i = 0; i < message.Length; i++)
        {
            textMeshProUGUI.text += message[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        IsTyping = false;
    }
    public void TypeInstant()
    {
        StopAllCoroutines();
        IsTyping = false;
        textMeshProUGUI.text = currentMessage;
    }
}