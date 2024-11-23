using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlatformMover : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float speed;
    [SerializeField] private float duration;

    [SerializeField] private int xOffset;
    [SerializeField] private int yOffset;

    private Vector2 start;
    private Vector2 end;

    private void Awake()
    {
        start = new Vector2(transform.position.x - xOffset, transform.position.y - yOffset);
        end = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(start, end, Mathf.PingPong(Time.time * speed, 1));
    }
}
