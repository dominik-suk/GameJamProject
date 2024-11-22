using UnityEngine;

[CreateAssetMenu(fileName = "Speaker", menuName = "Dialogue/Speaker", order = 0)]
public class Speaker : ScriptableObject {
    [field: SerializeField] public string Name{get; private set;}
    [field: SerializeField] public Sprite Sprite{get; private set;}
    [field: SerializeField] public Color TextColor{get; private set;} = Color.black;
    [field: SerializeField] public Color BackgroundColor{get; private set;} = Color.white;
    
}