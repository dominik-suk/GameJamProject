<<<<<<< Updated upstream
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
=======
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory Instance;
    [SerializeField] private List<Item> items = new();
    private int currentItemIndex = 0;
    public Item CurrentItem => items[currentItemIndex];
    public int NumberOfItems => items.Count;
    public static event Action OnUpdatedInventory;
    public static event Action<int> OnChangedSelectedItem;
    private void Awake() {
        if(Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void CollectItem(Item item)
    {
        if(ContainsItem(item)) return;
        items.Add(item);
        Debug.Log(item.name);
        OnUpdatedInventory?.Invoke();
    }
    public void ChangeSelectedItem(int direction) {
        currentItemIndex = currentItemIndex + direction % items.Count;
    }
    public bool ContainsItem(Item item)
    {
        return items.Find(x => x == item) != null;
    }
}
>>>>>>> Stashed changes
