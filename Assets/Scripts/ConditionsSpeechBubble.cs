using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConditionsSpeechBubble : MonoBehaviour
{
    private Image myImage;
    //private TextMeshProUGUI birdName;
    private TextMeshProUGUI birdConditions;

    [HideInInspector] public Bird hoveredBird;

    private void Awake()
    {
        myImage = GetComponent<Image>();
        //birdName = transform.Find("BirdName").GetComponent<TextMeshProUGUI>();
        birdConditions = transform.Find("BirdConditions").GetComponent<TextMeshProUGUI>();

        Clear();
    }

    public void Clear()
    {
        myImage.enabled = false;
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
            myImage.enabled = true;
        }
    }
}
