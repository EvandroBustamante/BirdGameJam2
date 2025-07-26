using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button nextDialogueButton;
    public Dialogue dialogue;

    private int dialogueLinesIndex;

    private void Awake()
    {
        nextDialogueButton.onClick.AddListener(NextDialogue);

        dialoguePanel.SetActive(false);

        StartDialogue();
    }

    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueLinesIndex = 0;
        dialogueText.text = dialogue.dialogueLines[dialogueLinesIndex];
    }

    private void NextDialogue()
    {
        if (dialogueLinesIndex < dialogue.dialogueLines.Length - 1)
        {
            dialogueLinesIndex++;
            dialogueText.text = dialogue.dialogueLines[dialogueLinesIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
