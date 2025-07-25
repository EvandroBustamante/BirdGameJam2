using UnityEngine;

public class Bird : MonoBehaviour
{
    public string myName;
    public string[] myConditions;

    public bool likesToBeQuiet;

    [HideInInspector] public BirdSlot myBirdSlot;
    private BirdSlot hoveredBirdSlot;
    private Vector3 startingPosition;
    private ConditionsSpeechBubble conditionUI;
    [HideInInspector] public ConditionsManager conditionsManager;
    [HideInInspector] public bool isSatisfied;

    [HideInInspector] public GameObject emojiHappy;
    [HideInInspector] public GameObject emojiSad;

    [HideInInspector] public bool conditionGenerics;

    [HideInInspector] public bool isPredatory;
    [HideInInspector] public bool isNoisy;

    public virtual void Awake()
    {
        startingPosition = transform.position;
        conditionUI = FindFirstObjectByType<ConditionsSpeechBubble>();
        conditionsManager = FindFirstObjectByType<ConditionsManager>();

        emojiHappy = transform.Find("EmojiHappy").gameObject;
        emojiSad = transform.Find("EmojiSad").gameObject;

        emojiHappy.SetActive(false);
        emojiSad.SetActive(false);

        isPredatory = false;
        isNoisy = false;
    }

    public void ReturnPosition()
    {
        if (hoveredBirdSlot)
        {
            if (hoveredBirdSlot.myBird == null)
            {
                if (myBirdSlot)
                    myBirdSlot.myBird = null;

                myBirdSlot = hoveredBirdSlot;
            }

            hoveredBirdSlot = null;
            myBirdSlot.myBird = this;

            transform.position = new Vector3(myBirdSlot.transform.position.x, myBirdSlot.transform.position.y, this.transform.position.z);
        }
        else
        {
            if (myBirdSlot)
                myBirdSlot.myBird = null;

            myBirdSlot = null;

            transform.position = startingPosition;
            emojiHappy.SetActive(false);
            emojiSad.SetActive(false);
        }

        conditionsManager.CheckAllBirds();
    }

    public virtual void CheckForConditionsMet()
    {
        conditionGenerics = false;

        bool isNextToNoisyBirds = false;

        if (likesToBeQuiet)
        {
            if (myBirdSlot)
            {
                foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
                {
                    if (AdjacentBirdSlot.myBird != null && AdjacentBirdSlot.myBird.isNoisy)
                    {
                        isNextToNoisyBirds = true;
                        break;
                    }
                }
            }
        }
        else
        {
            isNextToNoisyBirds = false;
        }

        if (!isNextToNoisyBirds)
            conditionGenerics = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BirdSlot"))
        {
            hoveredBirdSlot = collision.GetComponent<BirdSlot>();
        }
        else if (collision.CompareTag("ClearArea"))
        {
            hoveredBirdSlot = null;
        }
    }

    private void OnMouseOver()
    {
        conditionUI.ShowConditions(this);
    }

    private void OnMouseExit()
    {
        conditionUI.Clear();
    }
}
