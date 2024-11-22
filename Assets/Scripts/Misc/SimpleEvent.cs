using UnityEngine;
using UnityEngine.Events;

public class SimpleEvent : MonoBehaviour {
    [Header("Events")]
    public UnityEvent OnEnableEvent;
    private void OnEnable() {
       OnEnableEvent?.Invoke();
    }
}