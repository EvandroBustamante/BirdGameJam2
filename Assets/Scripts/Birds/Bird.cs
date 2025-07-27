using UnityEngine;

public class Bird : MonoBehaviour
{
    public string myName;
    public string[] myConditions;

    public bool likesToBeQuiet;
    public bool likesToBeClean;
    public bool doesntLikeDancing;

    public Sprite spriteNormal;
    public Sprite spriteHovering;
    public Sprite spritePlaced;

    public GameObject happyVFX;
    public GameObject sadVFX;

    [HideInInspector] public BirdSlot myBirdSlot;
    private BirdSlot hoveredBirdSlot;
    private Vector3 startingPosition;
    private ConditionsSpeechBubble conditionUI;
    private SpriteRenderer mySr;
    [HideInInspector] public ConditionsManager conditionsManager;
    [HideInInspector] public bool isSatisfied;

    [HideInInspector] public GameObject emojiHappy;
    [HideInInspector] public GameObject emojiSad;

    [HideInInspector] public bool conditionGenerics;

    [HideInInspector] public bool isPredatory;
    [HideInInspector] public bool isNoisy;
    [HideInInspector] public bool isDirty;
    [HideInInspector] public bool dances;

    public virtual void Awake()
    {
        startingPosition = transform.position;
        conditionUI = FindFirstObjectByType<ConditionsSpeechBubble>();
        conditionsManager = FindFirstObjectByType<ConditionsManager>();
        conditionsManager.OnAllBirdsSatisfied.AddListener(TurnOffEmojis);
        if(transform.Find("Sprite"))
            mySr = transform.Find("Sprite").GetComponent<SpriteRenderer>();

        emojiHappy = transform.Find("EmojiHappy").gameObject;
        emojiSad = transform.Find("EmojiSad").gameObject;

        TurnOffEmojis();

        isPredatory = false;
        isNoisy = false;
        isDirty = false;
        dances = false;
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

            if (mySr && spritePlaced)
                mySr.sprite = spritePlaced;

            transform.position = new Vector3(myBirdSlot.transform.position.x, myBirdSlot.transform.position.y, this.transform.position.z);
        }
        else
        {
            if (myBirdSlot)
                myBirdSlot.myBird = null;

            myBirdSlot = null;

            if (mySr && spriteNormal)
                mySr.sprite = spriteNormal;

            transform.position = startingPosition;
            emojiHappy.SetActive(false);
            emojiSad.SetActive(false);
        }

        if(myBirdSlot)
            conditionsManager.CheckAllBirds(false);
        else
            conditionsManager.CheckAllBirds(true);
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
                    if (AdjacentBirdSlot != null)
                    {
                        if (AdjacentBirdSlot.myBird != null && AdjacentBirdSlot.myBird.isNoisy)
                        {
                            isNextToNoisyBirds = true;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            isNextToNoisyBirds = false;
        }


        bool isNextToDirtyBirds = false;

        if (likesToBeClean)
        {
            if (myBirdSlot)
            {
                foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
                {
                    if (AdjacentBirdSlot != null)
                    {
                        if (AdjacentBirdSlot.myBird != null && AdjacentBirdSlot.myBird.isDirty)
                        {
                            isNextToDirtyBirds = true;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            isNextToDirtyBirds = false;
        }


        bool isNextToDancyBirds = false;

        if (doesntLikeDancing)
        {
            if (myBirdSlot)
            {
                foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
                {
                    if (AdjacentBirdSlot != null)
                    {
                        if (AdjacentBirdSlot.myBird != null && AdjacentBirdSlot.myBird.dances)
                        {
                            isNextToDancyBirds = true;
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            isNextToDancyBirds = false;
        }

        if (!isNextToNoisyBirds && !isNextToDirtyBirds && !isNextToDancyBirds)
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

        if (mySr && spriteHovering)
            mySr.sprite = spriteHovering;
    }

    private void OnMouseExit()
    {
        conditionUI.Clear();

        if(mySr && spriteNormal && spritePlaced)
        {
            if (myBirdSlot)
                mySr.sprite = spritePlaced;
            else
                mySr.sprite = spriteNormal;
        }
    }

    private void TurnOffEmojis()
    {
        emojiHappy.SetActive(false);
        emojiSad.SetActive(false);
    }

    public void SpawnHappyVFX()
    {
        GameObject vfx = Instantiate(happyVFX, emojiHappy.transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
    }

    public void SpawnSadVFX()
    {
        GameObject vfx = Instantiate(sadVFX, emojiSad.transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
    }
}
