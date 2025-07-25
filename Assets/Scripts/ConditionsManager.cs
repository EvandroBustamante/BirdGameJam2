using UnityEngine;

public class ConditionsManager : MonoBehaviour
{
    private Bird[] AllBirds;

    private void Awake()
    {
        AllBirds = FindObjectsByType<Bird>(FindObjectsSortMode.None);
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
    }

}
