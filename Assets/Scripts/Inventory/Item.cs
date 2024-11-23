using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject {
    [field:SerializeField] public int ID {get; private set;}
    [field:SerializeField] public Sprite Icon{get; private set;}
    public void Use()
    {
        Debug.Log("Item Used");
    }
}