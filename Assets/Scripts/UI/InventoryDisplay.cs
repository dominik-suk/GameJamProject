using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {
    [SerializeField] private Image previousItem, currentItem, nextItem;
    private void OnEnable() {
        Inventory.OnUpdatedInventory += UpdateDisplay;
        Inventory.OnChangedSelectedItem += UpdateDisplay;
    }
    private void OnDisable() {
        Inventory.OnUpdatedInventory -= UpdateDisplay;
        Inventory.OnChangedSelectedItem -= UpdateDisplay;
    }
    private void UpdateDisplay(int index)
    {
        UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        if(Inventory.Instance.NumberOfItems == 0) return;
        currentItem.sprite = Inventory.Instance.CurrentItem.Icon;
    }
}