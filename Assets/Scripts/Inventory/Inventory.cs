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
        currentItemIndex = (currentItemIndex + direction) % items.Count;
        OnChangedSelectedItem?.Invoke(currentItemIndex);
    }
    public bool ContainsItem(Item item)
    {
        return items.Find(x => x == item) != null;
    }
}
