using UnityEngine;

public interface IItem
{
    
    string ItemName { get; }
    
    string ItemDescription { get; }
    
    Sprite Icon { get; }
    
    void Use();
}