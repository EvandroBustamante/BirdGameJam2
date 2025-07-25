using UnityEngine;

public class SairaLenco : Bird
{
    //Saíra-lenço
    //Condição 1: não pode estar perto de predatórios
    //Condição 2: estar perto da água

    private bool conditionAwayFromPredatory = false;
    private bool conditionNearWater = false;

    public override void CheckForConditionsMet()
    {
        base.CheckForConditionsMet();

        if (myBirdSlot)
        {
            conditionAwayFromPredatory = true;
            foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
            {
                if (AdjacentBirdSlot.myBird != null && AdjacentBirdSlot.myBird.isPredatory)
                {
                    conditionAwayFromPredatory = false;
                    break;
                }
            }

            if (myBirdSlot.isNearWater)
            {
                conditionNearWater = true;
            }
            else
            {
                conditionNearWater = false;
            }
        }
        else
        {
            conditionAwayFromPredatory = false;
        }

        if (conditionGenerics && conditionAwayFromPredatory && conditionNearWater)
        {
            isSatisfied = true;
            emojiHappy.SetActive(true);
            emojiSad.SetActive(false);
        }
        else
        {
            isSatisfied = false;
            emojiHappy.SetActive(false);
            if (myBirdSlot)
                emojiSad.SetActive(true);
        }
    }
}
