using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class TriggerToEvent : MonoBehaviour
{
    [SerializeField]
    KeyCode triggerKey;
    [SerializeField]
    private UnityEvent triggerEvent;
    [SerializeField]
    private string ableToUseTag;
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEvent?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(triggerKey) && other.gameObject.tag == ableToUseTag)
        {
            triggerEvent?.Invoke();
        }
    }
}
