using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConditionsSpeechBubble : MonoBehaviour
{
    private GameObject bubble;
    //private TextMeshProUGUI birdName;
    private TextMeshProUGUI birdConditions;

    [HideInInspector] public Bird hoveredBird;

    private void Awake()
    {
        bubble = transform.Find("Bubble").gameObject;
        //birdName = transform.Find("BirdName").GetComponent<TextMeshProUGUI>();
        birdConditions = transform.Find("BirdConditions").GetComponent<TextMeshProUGUI>();

        Clear();
    }

    public void Clear()
    {
        bubble.SetActive(false);
        //birdName.enabled = false;
        birdConditions.enabled = false;

        hoveredBird = null;
    }

    public void ShowConditions(Bird newBird)
    {
        if(hoveredBird == null)
        {
            hoveredBird = newBird;
            //birdName.text = hoveredBird.myName;
            string newText = "";
            foreach (string Condition in hoveredBird.myConditions)
            {
                newText += Condition + "\n";
            }
            birdConditions.text = newText;

            //birdName.enabled = true;
            birdConditions.enabled = true;
            bubble.SetActive(true);
        }
    }
}
