using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private GameObject dialoguePanel;
    private TextMeshProUGUI dialogueText;
    private Button nextDialogueButton;
    private TMP_InputField inputField;
    private Button inputFieldButton;

    public Dialogue dialogue;
    public Dialogue dialogue2;
    public bool isLevel1 = false;
    public float dialogueTypeDelay;
    public bool noDialogue = false;

    private int dialogueLinesIndex;
    private string playerName;
    private Dialogue dialoguePlaying;

    private void Start()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialogueText = dialoguePanel.transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        nextDialogueButton = dialoguePanel.transform.Find("NextLineButton").GetComponent<Button>();
        inputField = GameObject.Find("DialogueInputField").GetComponent<TMP_InputField>();
        inputFieldButton = inputField.transform.Find("Ok").GetComponent<Button>();
        if (FindFirstObjectByType<NameStorer>())
            playerName = FindFirstObjectByType<NameStorer>().GetPlayerName();

        nextDialogueButton.onClick.AddListener(NextDialogue);
        inputFieldButton.onClick.AddListener(StartDialogue2);

        dialoguePanel.SetActive(false);
        inputField.gameObject.SetActive(false);

        if(!noDialogue)
            StartDialogue(dialogue);
    }

    private void StartDialogue(Dialogue thisDialogue)
    {
        dialoguePlaying = thisDialogue;
        dialoguePanel.SetActive(true);
        dialogueLinesIndex = 0;
        string finalDialogue = dialoguePlaying.dialogueLines[dialogueLinesIndex].Replace("[PLAYERNAME]", playerName);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(finalDialogue));
        AudioManager.Instance.PlayDialoguePopUp();
    }

    private void NextDialogue()
    {
        if (dialogueLinesIndex < dialoguePlaying.dialogueLines.Length - 1)
        {
            dialogueLinesIndex++;
            string finalDialogue = dialoguePlaying.dialogueLines[dialogueLinesIndex].Replace("[PLAYERNAME]", playerName);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(finalDialogue));
            AudioManager.Instance.PlayDialogueNext();
        }
        else
        {
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
            AudioManager.Instance.PlayDialogueClose();

            if (isLevel1)
            {
                isLevel1 = false;
                inputField.gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            AudioManager.Instance.PlayDialogueText();
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueTypeDelay);
        }
    }
     private void StartDialogue2()
    {
        playerName = inputField.text;
        if (FindFirstObjectByType<NameStorer>())
            FindFirstObjectByType<NameStorer>().SetPlayerName(playerName);
        inputField.gameObject.SetActive(false);
        StartDialogue(dialogue2);
    }
}
