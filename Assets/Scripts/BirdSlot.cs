using UnityEngine;

public class BirdSlot : MonoBehaviour
{
    public BirdSlot[] adjacentBirdSlots;
    public bool isLightSlot = false;
    public bool isNearWater = false;

    [HideInInspector] public Bird myBird;
}
