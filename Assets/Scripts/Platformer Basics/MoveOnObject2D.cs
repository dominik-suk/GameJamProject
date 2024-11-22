using System.Collections.Generic;
using UnityEngine;
public class MoveOnObject2D : MonoBehaviour
{
    private List<OtherObject> otherObjects = new();
    private void Start() {
        // Das Objekt muss die Größe 1 haben, ansonsten werden Objekte beim verlassen evtl. verformt
        transform.localScale = Vector3.one;
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        otherObjects.Add(new OtherObject(other.gameObject, other.transform.parent));
        other.transform.parent = transform;
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(this.gameObject.activeInHierarchy)
        {
            ResetParent(other.gameObject);
        }
    }
    private void ResetParent(GameObject gameObject)
    {
        OtherObject x = otherObjects.Find(x => x.gameObject = gameObject);
        if(x == null) return;
        x.gameObject.transform.parent = x.previousParent;

        otherObjects.Remove(x);
    }

    private class OtherObject
    {
        public GameObject gameObject;
        public Transform previousParent;

        public OtherObject(GameObject gameObject, Transform previousParent)
        {
            this.gameObject = gameObject;
            this.previousParent = previousParent;
        }
    }
}
