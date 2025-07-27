using UnityEngine;

public class QueroQuero : Bird
{
    //Quero-Quero
    //Condição 1: não pode estar perto de predatórios

    //Comportamento 1: é barulhento

    private bool conditionAwayFromPredatory = false;

    public override void Awake()
    {
        base.Awake();

        isNoisy = true;
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
