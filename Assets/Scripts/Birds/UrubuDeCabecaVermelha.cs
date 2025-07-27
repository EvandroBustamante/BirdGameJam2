using UnityEngine;

public class UrubuDeCabecaVermelha : Bird
{
    //Urubu de Cabeça Vermelha
    //Condição 1: Estar em lugar iluminado
    //Condição 2: Estar perto de outro pássaro

    //Comportamento 1: faz sujeira

    private bool conditionLightPlace;
    private bool conditionNextToBird;

    public override void Awake()
    {
        base.Awake();

        isDirty = true;
    }

    public override void CheckForConditionsMet()
    {
        base.CheckForConditionsMet();

        if (myBirdSlot)
        {
            if (myBirdSlot.isLightSlot == true)
                conditionLightPlace = true;
            else
                conditionLightPlace = false;

            conditionNextToBird = false;
            foreach (BirdSlot AdjacentBirdSlot in myBirdSlot.adjacentBirdSlots)
            {
                if (AdjacentBirdSlot != null)
                {
                    if (AdjacentBirdSlot.myBird != null)
                    {
                        conditionNextToBird = true;
                        break;
                    }
                }
            }
        }
        else
        {
            conditionLightPlace = false;
            conditionNextToBird = false;
        }

        if (conditionGenerics && conditionLightPlace && conditionNextToBird)
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
