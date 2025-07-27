using UnityEngine;

public class Tangara : Bird
{
    //Tangará
    //Condição 1: não pode estar perto de predatórios

    //Comportamento 1: dança

    private bool conditionAwayFromPredatory = false;

    public override void Awake()
    {
        base.Awake();

        dances = true;
    }

    public override void CheckForConditionsMet()
    {
        base.CheckForConditionsMet();

        if (myBirdSlot)
        {
            conditionAwayFromPredatory = true;
            foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
            {
                if (AdjacentBirdSlot != null)
                {
                    if (AdjacentBirdSlot.myBird != null && AdjacentBirdSlot.myBird.isPredatory)
                    {
                        conditionAwayFromPredatory = false;
                        break;
                    }
                }
            }
        }
        else
        {
            conditionAwayFromPredatory = false;
        }

        if (conditionGenerics && conditionAwayFromPredatory)
        {
            isSatisfied = true;
            emojiHappy.SetActive(true);
            emojiSad.SetActive(false);
            SpawnHappyVFX();
        }
        else
        {
            isSatisfied = false;
            emojiHappy.SetActive(false);
            if (myBirdSlot)
            {
                emojiSad.SetActive(true);
                SpawnSadVFX();
            }
        }
    }
}
