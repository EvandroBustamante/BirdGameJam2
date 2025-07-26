using UnityEngine;

public class BirdSlot : MonoBehaviour
{
    public BirdSlot[] adjacentBirdSlots;
    public bool isLightSlot = false;
    public bool isNearWater = false;
    public bool isNearFlower = false;

    [HideInInspector] public Bird myBird;

    private SpriteRenderer mySr;
    private DragAndDrop dragAndDrop;

    private void Awake()
    {
        mySr = GetComponent<SpriteRenderer>();
        dragAndDrop = FindFirstObjectByType<DragAndDrop>();

        mySr.enabled = false;
        dragAndDrop.beginDragEvent.AddListener(RevealSlot);
        dragAndDrop.endDragEvent.AddListener(HideSlot);
    }

    private void RevealSlot()
    {
        mySr.enabled = true;
    }

    private void HideSlot()
    {
        mySr.enabled = false;
    }
}
