using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue", order = 0)]
public class Dialogue : ScriptableObject {
    [field: SerializeField] public Line[] DialogueLines{get; private set;}
    [field: SerializeField] public Option[] DialogueOptions{get; private set;}

    #region Special Classes
    [Serializable] public class Line 
    {
        [TextArea] public string Text;
        public Speaker Speaker;
        [Tooltip("Wird anstelle der Standard Speakersprite verwendet")]
        public Sprite SpecialSprite;
    }
    [Serializable] public class Option
    {
        public string optionText;
        public Dialogue nextDialogueBranch;
    }   
#endregion
}

