using UnityEngine;

public class TopetinhoVermelho : Bird
{
    //Topetinho Vermelho
    //Comportamento 1: não pode estar perto de outro topetinho vermelho
    //Comportamento 2: precisa estar perto da flor

    private bool conditionOnlyHummingBird;
    private bool conditionIsNextToFlower;
    private bool conditionAwayFromPredatory = false;

    public override void CheckForConditionsMet()
    {
        base.CheckForConditionsMet();

        if (myBirdSlot)
        {
            conditionOnlyHummingBird = true;
            foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
            {
                if (AdjacentBirdSlot != null)
                {
                    if (AdjacentBirdSlot.myBird is TopetinhoVermelho)
                    {
                        conditionOnlyHummingBird = false;
                        break;
                    }
                }
            }

            if (myBirdSlot.isNearFlower == true)
                conditionIsNextToFlower = true;
            else
                conditionIsNextToFlower = false;

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
            conditionOnlyHummingBird = false;
            conditionIsNextToFlower = false;
            conditionAwayFromPredatory = false;
        }

        if (conditionGenerics && conditionOnlyHummingBird && conditionIsNextToFlower && conditionAwayFromPredatory)
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
