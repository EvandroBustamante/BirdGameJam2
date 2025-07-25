using UnityEngine;

public class SairaLenco : Bird
{
    //Sa�ra-len�o
    //Condi��o 1: n�o pode estar perto de predat�rios
    //Condi��o 2: estar perto da �gua

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
