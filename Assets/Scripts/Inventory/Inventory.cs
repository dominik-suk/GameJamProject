using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image lastItem;
    [SerializeField] private Image selectedItem;
    [SerializeField] private Image nextItem;

    [SerializeField] private List<GameObject> items;
    private int selectedItemIndex;
    
    private void Awake()
    {
        selectedItemIndex = 0;
    }

    public void SwitchItem(Vector2 input)
    {
        Debug.Log(input);
        Debug.Log(selectedItemIndex);
        selectedItemIndex += (int) input.y;
        selectedItemIndex = CutIndex(selectedItemIndex);
        var lastItemIndex = CutIndex(selectedItemIndex - 1);
        var nextItemIndex = CutIndex(selectedItemIndex + 1);
        
        lastItem.sprite = items.ElementAt(lastItemIndex).GetComponent<FlowerItem>().Icon;
        selectedItem.sprite = items.ElementAt(selectedItemIndex).GetComponent<FlowerItem>().Icon;
        nextItem.sprite = items.ElementAt(nextItemIndex).GetComponent<FlowerItem>().Icon;
    }

    private int CutIndex(int index)
    {
        const int minIndex = 0;
        var maxIndex = items.Count - 1;
        var newIndex = index;
        
        if (index > maxIndex)
        {
            newIndex = minIndex;
        }
        else if (index < minIndex)
        {
            newIndex = maxIndex;
        }

        return newIndex;
    }
    
    public void AddItem(GameObject newItem)
    {
        items.Add(newItem);
    }
}
