using UnityEngine;
using UnityEngine.Events;

public class TriggerOnEnter : MonoBehaviour {
    [SerializeField] private UnityEvent onEnterEvent;
    private void OnTriggerEnter2D(Collider2D other) {
        onEnterEvent?.Invoke();
        gameObject.SetActive(false);
    }
}