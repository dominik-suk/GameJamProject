using System;
using UnityEngine;

public class InteractionUI : MonoBehaviour {
    [Header("References")]
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private GameObject uiElement;
    private void OnEnable() {
        playerInteract.OnInteractionsAvailable += ShowUI;
        playerInteract.OnInteractionsUnavailable += HideUI;
    }

    private void ShowUI()
    {
        uiElement.SetActive(true);
    }
        private void HideUI()
    {
        uiElement.SetActive(false);
    }

    private void OnDisable() {
        playerInteract.OnInteractionsAvailable -= ShowUI;
        playerInteract.OnInteractionsUnavailable -= HideUI;
    }
}