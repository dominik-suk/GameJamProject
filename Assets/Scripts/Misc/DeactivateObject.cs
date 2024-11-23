using UnityEngine;

public class DeactivateObject : MonoBehaviour {
    public void Close()
    {
        gameObject.SetActive(false);
    }
}