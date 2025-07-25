using UnityEngine;

public class GaviaoPegaMacaco : Bird
{
    //Gavi�o Pega Macaco
    //Condi��o 1: solit�rio
    //Condi��o 2: lugar escuro

    //Comportamento: � predat�rio

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
                if (AdjacentBirdSlot.myBird != null)
                {
                    conditionSolitary = false;
                    break;
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
