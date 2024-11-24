using System;
using UnityEngine;

public class FlowerItem : MonoBehaviour, IItem
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite icon;
    
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public Sprite Icon { get; set; }

    private void Awake()
    {
        ItemName = itemName;
        ItemDescription = itemDescription;
        Icon = icon;
    }

    public void Use()
    {
        throw new NotImplementedException();
    }
}
