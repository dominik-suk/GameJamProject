using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {
    [SerializeField] private GameObject header;
    [SerializeField] private Image currentItem;
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
        if(Inventory.Instance.NumberOfItems == 0) 
        {
            header.SetActive(false);
            currentItem.gameObject.SetActive(false);
            return;
        }
        header.SetActive(true);
        currentItem.gameObject.SetActive(true);
        currentItem.sprite = Inventory.Instance.CurrentItem.Icon;
    }
}