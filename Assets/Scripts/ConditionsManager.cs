using UnityEngine;
using UnityEngine.UI;

public class ConditionsManager : MonoBehaviour
{
    private Bird[] AllBirds;
    private bool allBirdsSatisfied;

    private Button CompleteCheckButton;
    private GameObject failPopUp;

    private void Awake()
    {
        AllBirds = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        //CompleteCheckButton = F
    }

    public void CheckAllBirds()
    {
        int birdsSatisfied = 0;
        foreach (Bird Bird in AllBirds)
        {
            Bird.CheckForConditionsMet();
            if (Bird.isSatisfied)
                birdsSatisfied++;
        }

        Debug.Log("Birds satisfied: " + birdsSatisfied + "/" + AllBirds.Length);

        if(birdsSatisfied == AllBirds.Length)
        {
            allBirdsSatisfied = true;
        }
        else
        {
            allBirdsSatisfied = false;
        }
    }

}
