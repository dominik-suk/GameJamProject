using UnityEngine;
using UnityEngine.Events;

public class CollectItem : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] private Item item;

    [Header("Events")]
    [SerializeField] private UnityEvent itemCollectedEvent;

    private void Start() {
        // Debug.Log(Inventory.Instance.ContainsItem(item));
        // if(Inventory.Instance.ContainsItem(item)) Destroy(gameObject);
    }
    public void Interact()
    {
        // Inventory.Instance.CollectItem(item);
        itemCollectedEvent?.Invoke();
        Destroy(gameObject);
    }
}