using UnityEngine;

public class SwitchPhysicsLayer : MonoBehaviour {
    [Header("References")]
    [SerializeField] private GameObject[] layers;
    [Header("Settings")]
    [SerializeField] private int[] layerMasks;
    private int layerIndex = 0;
    public void SwitchLayer()
    {
        layerIndex = (layerIndex + 1) % layerMasks.Length;
        gameObject.layer = layerMasks[layerIndex];
    }
}