using UnityEngine;

public class CorujinhaDoMato : Bird
{
    //Corujinha do Mato
    //Condição 1: solitária
    //Condição 2: lugar escuro

    //Comportamento: é predatório

    private bool conditionSolitary = false;
    private bool conditionDarkPlace = false;

    public override void Awake()
    {
        base.Awake();

        isPredatory = true;
    }

    public override void CheckForConditionsMet()
    {
        base.CheckForConditionsMet();

        if (myBirdSlot)
        {
            conditionSolitary = true;
            foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
            {
                if (AdjacentBirdSlot != null)
                {
                    if (AdjacentBirdSlot.myBird != null)
                    {
                        conditionSolitary = false;
                        break;
                    }
                }
            }

            if (myBirdSlot.isLightSlot == false)
                conditionDarkPlace = true;
            else
                conditionDarkPlace = false;
        }
        else
        {
            conditionSolitary = false;
            conditionDarkPlace = false;
        }

        if (conditionGenerics && conditionSolitary && conditionDarkPlace)
        {
            isSatisfied = true;
            emojiHappy.SetActive(true);
            emojiSad.SetActive(false);
        }
        else
        {
            isSatisfied = false;
            emojiHappy.SetActive(false);
            if(myBirdSlot)
                emojiSad.SetActive(true);
        }
    }
}
