using UnityEngine;

public class Carcara : Bird
{
    //Carcará
    //Condição 1: solitário
    //Condição 2: lugar claro

    //Comportamento: é predatório

    private bool conditionSolitary = false;
    private bool conditionLightPlace = false;

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

            if (myBirdSlot.isLightSlot == true)
                conditionLightPlace = true;
            else
                conditionLightPlace = false;
        }
        else
        {
            conditionSolitary = false;
            conditionLightPlace = false;
        }

        if (conditionGenerics && conditionSolitary && conditionLightPlace)
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
