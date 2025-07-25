using UnityEngine;
using DG.Tweening;

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

        mySr.color = new Color(mySr.color.r, mySr.color.g, mySr.color.b, 0);
        dragAndDrop.beginDragEvent.AddListener(RevealSlot);
        dragAndDrop.endDragEvent.AddListener(HideSlot);
    }

    private void RevealSlot()
    {
        //mySr.enabled = true;
        mySr.DOFade(0.15f, 0.5f);

    }

    private void HideSlot()
    {
        mySr.DOFade(0, 0.5f);
        //mySr.enabled = false;
    }
}
