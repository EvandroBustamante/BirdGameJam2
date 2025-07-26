using UnityEngine;

public class TopetinhoVermelho : Bird
{
    //Topetinho Vermelho
    //Comportamento 1: não pode estar perto de outro topetinho vermelho
    //Comportamento 2: precisa estar perto da flor

    private bool conditionOnlyHummingBird;
    private bool conditionIsNextToFlower;

    public override void CheckForConditionsMet()
    {
        base.CheckForConditionsMet();

        if (myBirdSlot)
        {
            conditionOnlyHummingBird = true;
            foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
            {
                if (AdjacentBirdSlot.myBird is TopetinhoVermelho)
                {
                    conditionOnlyHummingBird = false;
                    break;
                }
            }

            if (myBirdSlot.isNearFlower == true)
                conditionIsNextToFlower = true;
            else
                conditionIsNextToFlower = false;
        }
        else
        {
            conditionOnlyHummingBird = false;
            conditionIsNextToFlower = false;
        }

        if (conditionGenerics && conditionOnlyHummingBird && conditionIsNextToFlower)
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
