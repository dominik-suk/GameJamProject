using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    [SerializeField]
    private UnityEvent test;
    private void Start()
    {
        if (test != null) 
        { 
            test = new UnityEvent();
        }
        test.AddListener(interacted);
    }

    private void interacted()
    {
        gameObject.transform.localScale = new Vector3(10, 1, 1);
    }
}
