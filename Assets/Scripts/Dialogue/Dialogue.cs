using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextArea(3,3)]
    public string[] dialogueLines;
}
